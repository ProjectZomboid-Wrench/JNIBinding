using System.Runtime.InteropServices;

namespace JNIBinding.Bindings.Native.Types;

[StructLayout(LayoutKind.Sequential)]
public readonly struct _JLongArray
{
    public readonly IntPtr Value;
    
    public bool IsNull => Value == IntPtr.Zero;
    public override string ToString() => $"{nameof(_JObjectArray)}[{Value:X16}]";
    
    public static implicit operator IntPtr(_JLongArray jniRef) => jniRef.Value;
}