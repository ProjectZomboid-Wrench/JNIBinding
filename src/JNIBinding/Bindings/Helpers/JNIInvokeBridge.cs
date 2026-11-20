using JNIBinding.Bindings.Native;

namespace JNIBinding;

/// <summary>A JavaVM's invocation interface as typed unmanaged function pointers.</summary>
public sealed unsafe class JNIInvokeBridge(JNIInvokeInterface functions)
{
    public readonly delegate* unmanaged<IntPtr, int> DestroyJavaVM = (delegate* unmanaged<IntPtr, int>)functions.DestroyJavaVM;
    public readonly delegate* unmanaged<IntPtr, IntPtr*, JvmInitArgs*, int> AttachCurrentThread = (delegate* unmanaged<IntPtr, IntPtr*, JvmInitArgs*, int>)functions.AttachCurrentThread;
    public readonly delegate* unmanaged<IntPtr, int> DetachCurrentThread = (delegate* unmanaged<IntPtr, int>)functions.DetachCurrentThread;
    public readonly delegate* unmanaged<IntPtr, IntPtr*, int, int> GetEnv = (delegate* unmanaged<IntPtr, IntPtr*, int, int>)functions.GetEnv;
    public readonly delegate* unmanaged<IntPtr, IntPtr*, JvmInitArgs*, int> AttachCurrentThreadAsDaemon = (delegate* unmanaged<IntPtr, IntPtr*, JvmInitArgs*, int>)functions.AttachCurrentThreadAsDaemon;
}
