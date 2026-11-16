using System.Runtime.InteropServices;

namespace JNIBinding.Bindings.Native;

[StructLayout(LayoutKind.Sequential, Pack = 0)]
public struct JvmOption
{
    public IntPtr optionString;
    public IntPtr extraInfo;
}