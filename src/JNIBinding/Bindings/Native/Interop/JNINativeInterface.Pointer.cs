using System.Runtime.InteropServices;

namespace JNIBinding.Bindings.Native;

[StructLayout(LayoutKind.Sequential, Size = 4)]
public struct JNINativeInterfacePtr
{
    public readonly unsafe JNINativeInterface* functions;
}