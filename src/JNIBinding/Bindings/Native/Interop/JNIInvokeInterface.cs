using System.Runtime.InteropServices;

namespace JNIBinding.Bindings.Native;

[StructLayout(LayoutKind.Sequential)]
public struct JNIInvokeInterface
{
    public IntPtr reserved0;
    public IntPtr reserved1;
    public IntPtr reserved2;

    // jint (JNICall *DestroyJavaVM)(JavaVM *vm);
    public IntPtr DestroyJavaVM;
    
    // jint (JNICall *AttachCurrentThread)(JavaVM *vm, void **penv, void *args);
    public IntPtr AttachCurrentThread;
    
    // jint (JNICall *DetachCurrentThread)(JavaVM *vm);
    public IntPtr DetachCurrentThread;
    
    // jint (JNICall *GetEnv)(JavaVM *vm, void **penv, jint version);
    public IntPtr GetEnv;
    
    // jint (JNICall *AttachCurrentThreadAsDaemon)(JavaVM *vm, void **penv, void *args);
    public IntPtr AttachCurrentThreadAsDaemon;
}