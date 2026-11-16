using System.Runtime.InteropServices;

namespace JNIBinding.Bindings.Native;

public unsafe struct JNIInvokeInterface_
{
    // int (int* pVM)
    public delegate* unmanaged[Stdcall] <int, int*> fnDestroyJavaVM;
    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    public delegate int DestroyJavaVM(IntPtr pVM);

    // int (int*,int*, JvmInitArgs*)
    public delegate* unmanaged[Stdcall] <int, int*, int*, JvmInitArgs*> fnAttachCurrentThread;
    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    public unsafe delegate int AttachCurrentThread(IntPtr pVM, out IntPtr pEnv, JvmInitArgs* args);

    // int (int*)
    public delegate* unmanaged[Stdcall] <int,int*> fnDetachCurrentThread;
    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    public delegate int DetachCurrentThread(IntPtr pVM);

    // int (int*,int*,int)
    public delegate* unmanaged[Stdcall] <int, int*, int*, int> fnGetEnv;
    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    public delegate int GetEnv(IntPtr pVM, out IntPtr pEnv, int version);

    // int (int*,int*,JvmInitArgs*)
    public delegate* unmanaged[Stdcall] <int, int*, int*, JvmInitArgs*> fnAttachCurrentThreadAsDaemon;
    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    public unsafe delegate int AttachCurrentThreadAsDaemon(IntPtr pVM, out IntPtr pEnv, JvmInitArgs* args);
}

public class JNIInvokeBridge(JNIInvokeInterface functions)
{
    public readonly JNIInvokeInterface _binding = functions;

    [JNIFunctionBinding(nameof(JNIInvokeInterface.DestroyJavaVM))]
    public JNIInvokeInterface_.DestroyJavaVM DestroyJavaVM { get; init; }

    [JNIFunctionBinding(nameof(JNIInvokeInterface.AttachCurrentThread))]
    public JNIInvokeInterface_.AttachCurrentThread AttachCurrentThread { get; init; }

    [JNIFunctionBinding(nameof(JNIInvokeInterface.DetachCurrentThread))]
    public JNIInvokeInterface_.DetachCurrentThread DetachCurrentThread { get; init; }

    [JNIFunctionBinding(nameof(JNIInvokeInterface.GetEnv))]
    public JNIInvokeInterface_.GetEnv GetEnv { get; init; }

    [JNIFunctionBinding(nameof(JNIInvokeInterface.AttachCurrentThreadAsDaemon))]
    public JNIInvokeInterface_.AttachCurrentThreadAsDaemon AttachCurrentThreadAsDaemon { get; init; }
}