using System.Runtime.InteropServices;

namespace JNIBinding.Bindings.Native.Types;

[StructLayout(LayoutKind.Sequential)]
public readonly struct _JArray(IntPtr value)
{
    public readonly IntPtr Value = value;
    
    public bool IsNull => Value == IntPtr.Zero;
    public override string ToString() => $"{nameof(_JArray)}[{Value:X16}]";
    
    public static implicit operator IntPtr(_JArray jniRef) => jniRef.Value;

    public static implicit operator _JArray(_JCharArray v) => new(v);
    public static implicit operator _JArray(_JByteArray v) => new(v);
    public static implicit operator _JArray(_JShortArray v) => new(v);
    public static implicit operator _JArray(_JIntArray v) => new(v);
    public static implicit operator _JArray(_JLongArray v) => new(v);
    public static implicit operator _JArray(_JBooleanArray v) => new(v);
    public static implicit operator _JArray(_JFloatArray v) => new(v);
    public static implicit operator _JArray(_JDoubleArray v) => new(v);
    public static implicit operator _JArray(_JObjectArray v) => new(v);
}