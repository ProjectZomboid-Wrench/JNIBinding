using System.Runtime.InteropServices;
using JNIBinding.Bindings.Native;
using JNIBinding.Diagnostics;

namespace JNIBinding.Bindings;

/// <summary>
/// Locates and loads the platform's JVM library (jvm.dll, libjvm.so or libjvm.dylib) and exposes
/// its exported invocation API.
/// </summary>
/// <remarks>
/// Resolution order: an explicit path, <c>JAVA_HOME</c>, the bare library name (which also matches a
/// JVM already loaded into this process), then the <c>java</c> executable found on <c>PATH</c>.
/// </remarks>
public sealed unsafe class JvmLibrary : IVMRef
{
    private readonly string? _explicitPath;
    private readonly string? _javaHome;

    private delegate* unmanaged<IntPtr*, IntPtr*, JvmInitArgs*, JniResult> _createJavaVM;
    private delegate* unmanaged<IntPtr*, int, int*, JniResult> _getCreatedJavaVMs;
    private delegate* unmanaged<JvmInitArgs*, JniResult> _getDefaultJavaVMInitArgs;

    public JvmLibrary(string? libraryPath = null)
    {
        _explicitPath = libraryPath;
    }

    private JvmLibrary(string? libraryPath, string javaHome) : this(libraryPath)
    {
        _javaHome = javaHome;
    }

    /// <summary>Resolves the library inside a specific Java home, e.g. the running JVM's <c>java.home</c>.</summary>
    public static JvmLibrary ForJavaHome(string javaHome) => new(null, javaHome);

    public string VMLibraryName =>
        OperatingSystem.IsWindows() ? "jvm.dll" :
        OperatingSystem.IsMacOS() ? "libjvm.dylib" :
        "libjvm.so";

    public string? LoadedFrom { get; private set; }

    public bool IsLoaded => _createJavaVM != null;

    public void LoadLibrary()
    {
        if (IsLoaded)
            return;

        var (handle, source) = Resolve();
        _createJavaVM = (delegate* unmanaged<IntPtr*, IntPtr*, JvmInitArgs*, JniResult>)
            NativeLibrary.GetExport(handle, "JNI_CreateJavaVM");
        _getCreatedJavaVMs = (delegate* unmanaged<IntPtr*, int, int*, JniResult>)
            NativeLibrary.GetExport(handle, "JNI_GetCreatedJavaVMs");
        _getDefaultJavaVMInitArgs = (delegate* unmanaged<JvmInitArgs*, JniResult>)
            NativeLibrary.GetExport(handle, "JNI_GetDefaultJavaVMInitArgs");

        LoadedFrom = source;
        JniLog.Debug("JvmLibrary", $"Loaded {VMLibraryName} from {source}");
    }

    public JniResult CreateVM(out IntPtr pVM, out IntPtr pEnv, JvmInitArgs* args)
    {
        EnsureLoaded();
        IntPtr vm, env;
        var res = _createJavaVM(&vm, &env, args);
        pVM = vm;
        pEnv = env;
        return res;
    }

    public JniResult GetCreatedVMs(out IntPtr pVM, int size, out int sizeOut)
    {
        EnsureLoaded();
        IntPtr vm;
        int count;
        var res = _getCreatedJavaVMs(&vm, size, &count);
        pVM = vm;
        sizeOut = count;
        return res;
    }

    public JniResult GetDefaultArgs(JvmInitArgs* args)
    {
        EnsureLoaded();
        return _getDefaultJavaVMInitArgs(args);
    }

    private void EnsureLoaded()
    {
        if (!IsLoaded)
            LoadLibrary();
    }

    private (IntPtr Handle, string Source) Resolve()
    {
        var tried = new List<string>();

        if (_explicitPath is not null)
        {
            if (NativeLibrary.TryLoad(_explicitPath, out var h))
                return (h, _explicitPath);
            throw new DllNotFoundException($"Unable to load JVM library from '{_explicitPath}'");
        }

        if (_javaHome is not null)
        {
            if (TryLoadFromJavaHome(_javaHome, tried, out var fromGiven))
                return fromGiven;
            throw new DllNotFoundException($"Unable to locate {VMLibraryName} under '{_javaHome}'. Tried: {string.Join(", ", tried)}");
        }

        var javaHome = Environment.GetEnvironmentVariable("JAVA_HOME");
        if (!string.IsNullOrEmpty(javaHome) && TryLoadFromJavaHome(javaHome, tried, out var fromHome))
            return fromHome;

        tried.Add(VMLibraryName);
        if (NativeLibrary.TryLoad(VMLibraryName, out var byName))
            return (byName, VMLibraryName);

        var javaOnPath = FindJavaHomeFromPath();
        if (javaOnPath is not null && TryLoadFromJavaHome(javaOnPath, tried, out var fromPath))
            return fromPath;

        throw new DllNotFoundException(
            $"Unable to locate {VMLibraryName}. Set JAVA_HOME or put java on PATH. Tried: {string.Join(", ", tried)}");
    }

    private bool TryLoadFromJavaHome(string javaHome, List<string> tried, out (IntPtr, string) result)
    {
        var candidates = KnownLibraryLocations()
            .Select(rel => Path.Combine(javaHome, rel))
            .Where(File.Exists)
            .ToList();

        // Fallback for unusual layouts (e.g. JDK 8 lib/<arch>/server), slower but exhaustive.
        if (candidates.Count == 0 && Directory.Exists(javaHome))
            candidates.AddRange(Directory.EnumerateFiles(javaHome, VMLibraryName, SearchOption.AllDirectories));

        foreach (var path in candidates)
        {
            tried.Add(path);
            if (NativeLibrary.TryLoad(path, out var handle))
            {
                result = (handle, path);
                return true;
            }
        }

        tried.Add($"{javaHome} (no {VMLibraryName} found)");
        result = default;
        return false;
    }

    private IEnumerable<string> KnownLibraryLocations()
    {
        if (OperatingSystem.IsWindows())
            return [Path.Combine("bin", "server", VMLibraryName), Path.Combine("jre", "bin", "server", VMLibraryName)];
        return [Path.Combine("lib", "server", VMLibraryName), Path.Combine("jre", "lib", "server", VMLibraryName)];
    }

    private static string? FindJavaHomeFromPath()
    {
        var exe = OperatingSystem.IsWindows() ? "java.exe" : "java";
        var paths = Environment.GetEnvironmentVariable("PATH")?.Split(Path.PathSeparator) ?? [];
        var javaPath = paths
            .Where(p => !string.IsNullOrWhiteSpace(p))
            .Select(p => Path.Combine(p, exe))
            .FirstOrDefault(File.Exists);
        if (javaPath is null)
            return null;

        // /usr/bin/java is usually a symlink chain into the real JDK (e.g. via /etc/alternatives).
        var resolved = File.ResolveLinkTarget(javaPath, returnFinalTarget: true)?.FullName ?? javaPath;
        var binDir = Path.GetDirectoryName(resolved);
        return binDir is null ? null : Path.GetDirectoryName(binDir);
    }
}
