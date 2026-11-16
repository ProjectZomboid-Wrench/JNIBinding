using System.Runtime.InteropServices;

namespace JNIBinding.Bindings.Native;

[StructLayout(LayoutKind.Sequential, Size = 4)]
public struct JNIInvokeInterfacePtr
{
    public readonly unsafe JNIInvokeInterface* functions;
}