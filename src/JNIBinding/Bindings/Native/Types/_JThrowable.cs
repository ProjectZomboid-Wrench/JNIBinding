using System.Runtime.InteropServices;

namespace JNIBinding.Bindings.Native.Types;

[StructLayout(LayoutKind.Sequential)]
public readonly struct _JThrowable(IntPtr value)
{
    public readonly IntPtr Value = value;
    
    public bool IsNull => Value == IntPtr.Zero;
    public override string ToString() => $"{nameof(_JThrowable)}[{Value:X16}]";
    
    public static implicit operator IntPtr(_JThrowable jniRef) => jniRef.Value;
    public static implicit operator _JThrowable(IntPtr ptr) => new _JThrowable(ptr);
}