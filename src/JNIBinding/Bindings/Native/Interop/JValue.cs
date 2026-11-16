using System.Runtime.InteropServices;

namespace JNIBinding.Bindings.Native;

[Obsolete("Use _JValue instead")]
[StructLayout(LayoutKind.Explicit)]
public struct JValue__
{
    [FieldOffset(0)] public byte z;
    [FieldOffset(1)] public byte b;
    [FieldOffset(2)] public char c;
    [FieldOffset(3)] public short s;
    [FieldOffset(4)] public int i;
    [FieldOffset(5)] public long j;
    [FieldOffset(6)] public float f;
    [FieldOffset(6)] public double d;
    [FieldOffset(7)] public IntPtr l;
}