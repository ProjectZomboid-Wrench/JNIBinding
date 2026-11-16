using JNIBinding.Bindings.Native;

namespace JNIBinding.Bindings;

public interface IVMRef
{
    string VMLibraryName { get; }

    void LoadLibrary();
    
    unsafe JniResult CreateVM(out IntPtr pVM, out IntPtr pEnv, JvmInitArgs* args);

    JniResult GetCreatedVMs(out IntPtr pVM, int size, out int sizeOut);

    unsafe JniResult GetDefaultArgs(JvmInitArgs* args);
}