using System.Runtime.InteropServices;

namespace JNIBinding.Bindings.Native;

[StructLayout(LayoutKind.Sequential, Pack = 0)]
public unsafe struct JvmInitArgs
{
    public int version;
    public int nOptions;
    public JvmOption* options;
    public byte ignoreUnrecognized;
}