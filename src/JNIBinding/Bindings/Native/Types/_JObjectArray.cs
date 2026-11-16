using System.Runtime.InteropServices;

namespace JNIBinding.Bindings.Native.Types;

[StructLayout(LayoutKind.Sequential)] 
public readonly struct _JObjectArray(IntPtr value)
{
    public readonly IntPtr Value = value;
    
    public bool IsNull => Value == IntPtr.Zero;
    public override string ToString() => $"{nameof(_JObjectArray)}[{Value:X16}]";
    
    public static implicit operator IntPtr(_JObjectArray jniRef) => jniRef.Value;
}