using System.Runtime.InteropServices;

namespace JNIBinding.Bindings.Native.Types;

[StructLayout(LayoutKind.Sequential)]
public readonly struct _JString(IntPtr value)
{
    public readonly IntPtr Value = value;
    
    public bool IsNull => Value == IntPtr.Zero;
    public override string ToString() => $"{nameof(_JString)}[{Value:X16}]";
    
    public static implicit operator IntPtr(_JString jniRef) => jniRef.Value;
    public static implicit operator _JString(IntPtr jniRef) => new(jniRef);
}