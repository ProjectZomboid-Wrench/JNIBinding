namespace JNIBinding.Bindings.Native.Types;

public readonly struct _JMethodID(IntPtr value)
{
    public readonly IntPtr Value = value;
    
    public bool IsNull => Value == IntPtr.Zero;
    public override string ToString() => $"{nameof(_JMethodID)}[{Value:X16}]";
    
    public static implicit operator IntPtr(_JMethodID jniRef) => jniRef.Value;
}