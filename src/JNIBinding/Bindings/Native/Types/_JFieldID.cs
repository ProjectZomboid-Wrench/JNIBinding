using System.Runtime.InteropServices;

namespace JNIBinding.Bindings.Native.Types;

[StructLayout(LayoutKind.Sequential)]
public readonly struct _JFieldID(IntPtr value)
{
    public readonly IntPtr Value = value;
    
    public bool IsNull => Value == IntPtr.Zero;
    
    public override string ToString() => $"{nameof(_JFieldID)}[{Value:X16}]";
    
    public static implicit operator IntPtr(_JFieldID jniRef) => jniRef.Value;
    public static implicit operator _JFieldID(IntPtr value) => new(value);
}