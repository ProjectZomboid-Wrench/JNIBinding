using JNIBinding.Bindings;
using JNIBinding.Bindings.Decorated;
using JNIBinding.Bindings.Native.Types;
using JNIBinding.Exceptions;

namespace JNIBinding;

/// <summary>
/// Decorated API bound to one thread's <see cref="JNIEnv"/>. Don't share an instance across threads;
/// use <see cref="ForCurrentThread"/> to get one for another thread.
/// </summary>
public class JavaRuntime(JVM vm, JNIEnv env)
{
    private readonly JNIEnv _env = env;

    public JVM VM { get; } = vm;

    public JNIEnv Env => _env;

    public void PushLocalFrame(int capacity) => _env.PushLocalFrame(capacity);

    public void PopLocalFrame() => _env.PopLocalFrame(_JObject.Null);

    public _JString AllocateStringAnsi(string s) => _env.NewStringAnsi(s);

    public JavaClass FindClass(string className)
    {
        if (className.Contains("/"))
            throw new ArgumentException("Use dot notation rather than JNI slashed notation");

        var cls = _env.FindClass(className.Replace(".", "/"));
        if (cls.IsNull)
            throw new JNIClassNotFoundException(className);

        return new JavaClass(_env, ref cls, className, this);
    }

    public JavaRuntime ForCurrentThread() => new(VM, VM.GetOrAttachEnv());

    /// <summary>Creates the JVM, or joins the one already running in this process.</summary>
    public static JavaRuntime Bootstrap(IVMRef bootstrapper, params string[] jvmArgs)
    {
        bootstrapper.LoadLibrary();
        var vm = JVM.CreateOrGetCreated(bootstrapper, [..jvmArgs, "-Xcheck:jni", "-verbose:jni"]);
        return new JavaRuntime(vm, vm.GetOrAttachEnv());
    }

    /// <summary>Wraps a VM handed to native code by the JVM, e.g. the JavaVM* passed to JNI_OnLoad.</summary>
    public static JavaRuntime FromExisting(_JVM handle)
    {
        var vm = new JVM(handle);
        return new JavaRuntime(vm, vm.GetOrAttachEnv());
    }
}
