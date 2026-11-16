using System.Runtime.InteropServices;

namespace JNIBinding.Bindings.Native.Types;

/*
 * V - void
 * Z - boolean
 * C - char
 * B - byte
 * S - short
 * I - int
 * F - float
 * J - long
 * D - double
 * L - Reference
 */

[StructLayout(LayoutKind.Explicit, Size = 8)]
public readonly struct _JValue
{
    [FieldOffset(0)] private readonly long _raw;
    
    [FieldOffset(0)] public readonly _JBoolean Bool;
    [FieldOffset(0)] public readonly Byte Byte;
    [FieldOffset(0)] public readonly UInt16 Char;
    [FieldOffset(0)] public readonly Int16 Short;
    [FieldOffset(0)] public readonly Int32 Int;
    [FieldOffset(0)] public readonly Int64 Long;
    [FieldOffset(0)] public readonly Single Float;
    [FieldOffset(0)] public readonly Double Double;
    [FieldOffset(0)] public readonly _JObject Ref;

    public override string ToString() => $"{nameof(_JValue)}[{_raw:X16}]";
    
    public _JValue(_JBoolean b) : this()
    {
        Bool = b;
    }

    public _JValue(Byte b) : this()
    {
        Byte = b;
    }
    
    public _JValue(UInt16 c) : this()
    {
        Char = c;
    }

    public _JValue(Int16 s) : this()
    {
        Short = s;
    }

    public _JValue(Int32 i) : this()
    {
        Int = i;
    }

    public _JValue(Int64 l) : this()
    {
        Long = l;
    }

    public _JValue(Single f) : this()
    {
        Float = f;
    }

    public _JValue(Double d) : this()
    {
        Double = d;
    }

    public _JValue(_JObject o) : this()
    {
        Ref = o;
    }
}