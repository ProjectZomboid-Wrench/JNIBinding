using System.Diagnostics;
using System.Runtime.InteropServices;
using JNIBinding.Bindings;
using JNIBinding.Bindings.Native;
using JNIBinding.Bindings.Native.Interop;
using JNIBinding.Bindings.Native.Types;
using JNIBinding.Exceptions;

namespace JNIBinding;

[StructLayout(LayoutKind.Sequential)]
public readonly struct _JVM(IntPtr jvmPtr)
{
    public readonly IntPtr Value = jvmPtr;

    public bool IsNull => Value == IntPtr.Zero;
    public override string ToString() => $"&{nameof(_JVM)}[0x{Value:X16}]";

    public static implicit operator IntPtr(_JVM v) => v.Value;

    public unsafe void* ToPointer() => Value.ToPointer();
}

/// <summary>
/// API over a JavaVM* and its JNIInvokeInterface. A process can host only one JVM, so obtain
/// instances through <see cref="Create"/>, <see cref="GetCreated"/> or <see cref="CreateOrGetCreated"/>,
/// or wrap a handle received from <c>JNI_OnLoad</c>.
/// </summary>
public sealed unsafe class JVM
{
    public _JVM Handle { get; }
    public JNIInvokeBridge Functions { get; }

    public JVM(_JVM handle)
    {
        if (handle.IsNull)
            throw new ArgumentException("JavaVM handle is null", nameof(handle));

        Handle = handle;
        var table = (*(JNIInvokeInterfacePtr*)handle.ToPointer()).functions;
        Functions = new JNIInvokeBridge(*table);
        JNIFunctionBinder.Bind(Functions, *table);
    }

    /// <summary>Creates the process's JVM. The calling thread is attached to it.</summary>
    public static JVM Create(IVMRef vmRef, IEnumerable<string> options,
        JniVersion version = JniVersion.JNI_VERSION_1_6)
    {
        var optionList = options.ToArray();
        var nativeOptions = (JvmOption*)NativeMemory.AllocZeroed((nuint)Math.Max(optionList.Length, 1),
            (nuint)sizeof(JvmOption));
        try
        {
            for (var i = 0; i < optionList.Length; i++)
                nativeOptions[i].optionString = Marshal.StringToHGlobalAnsi(optionList[i]);

            var args = new JvmInitArgs
            {
                version = (int)version,
                nOptions = optionList.Length,
                options = nativeOptions,
                ignoreUnrecognized = (byte)JBoolean.JNI_TRUE,
            };

            var result = vmRef.CreateVM(out var pVM, out _, &args);
            if (result != JniResult.Success)
                throw new JNIException($"JNI_CreateJavaVM failed: {result}");
            return new JVM(new _JVM(pVM));
        }
        finally
        {
            // The VM copies option strings during creation, so they can be released afterwards.
            for (var i = 0; i < optionList.Length; i++)
                Marshal.FreeHGlobal(nativeOptions[i].optionString);
            NativeMemory.Free(nativeOptions);
        }
    }

    /// <summary>Returns the JVM already running in this process, or null if there is none.</summary>
    public static JVM? GetCreated(IVMRef vmRef)
    {
        var res = vmRef.GetCreatedVMs(out var pVM, 1, out var count);
        if (res != JniResult.Success)
            throw new JNIException($"JNI_GetCreatedJavaVMs failed: {res}");
        return count > 0 ? new JVM(new _JVM(pVM)) : null;
    }

    public static JVM CreateOrGetCreated(IVMRef vmRef, IEnumerable<string> options,
        JniVersion version = JniVersion.JNI_VERSION_1_6)
        => GetCreated(vmRef) ?? Create(vmRef, options, version);

    /// <summary>Returns the calling thread's JNIEnv, or null if the thread isn't attached.</summary>
    public JNIEnv? GetEnv(JniVersion version = JniVersion.JNI_VERSION_1_6)
    {
        var res = (JniResult)Functions.GetEnv(Handle, out var pEnv, (int)version);
        return res switch
        {
            JniResult.Success => new JNIEnv(new _JNIEnv(pEnv)),
            JniResult.ThreadDetached => null,
            _ => throw new JNIException($"GetEnv failed: {res}"),
        };
    }

    public JNIEnv AttachCurrentThread(bool asDaemon = false)
    {
        IntPtr pEnv;
        var res = (JniResult)(asDaemon
            ? Functions.AttachCurrentThreadAsDaemon(Handle, out pEnv, null)
            : Functions.AttachCurrentThread(Handle, out pEnv, null));
        if (res != JniResult.Success)
            throw new JNIException($"AttachCurrentThread failed: {res}");
        return new JNIEnv(new _JNIEnv(pEnv));
    }

    public JNIEnv GetOrAttachEnv(JniVersion version = JniVersion.JNI_VERSION_1_6)
        => GetEnv(version) ?? AttachCurrentThread();

    public void DetachCurrentThread()
    {
        var res = (JniResult)Functions.DetachCurrentThread(Handle);
        if (res != JniResult.Success)
            throw new JNIException($"DetachCurrentThread failed: {res}");
    }

    /// <summary>Unloads the JVM. HotSpot does not support creating another JVM in the same process afterwards.</summary>
    public JniResult Destroy() => (JniResult)Functions.DestroyJavaVM(Handle);

    public override string ToString() => $"{nameof(JVM)} ({Handle})";

    public static T Wrap<T>(nint _ptr) where T : Delegate
    {
        Debug.WriteLine($"[TRACE][JVM] ResolveFunctionPointer: {typeof(T)}(0x{_ptr:x4})");
        T res = null!;
        GetDelegateForFunctionPointer(_ptr, ref res);
        if (res == null)
            throw new ArgumentException($"Unable to wrap {typeof(T)} around (0x{_ptr:x4})");
        return res;
    }

    public static void GetDelegateForFunctionPointer<T>(IntPtr ptr, ref T res)
    {
        res = Marshal.GetDelegateForFunctionPointer<T>(ptr);
    }
}
