namespace JNIBinding.Bindings.Native.Types;

public readonly struct _JByteArray(IntPtr value)
{
    public readonly IntPtr Value = value;
    
    public bool IsNull => Value == IntPtr.Zero;
    
    public override string ToString() => $"{nameof(_JByteArray)}[{Value:X16}]";
    
    public static implicit operator IntPtr(_JByteArray jniRef) => jniRef.Value;
    public static implicit operator _JByteArray(IntPtr ptr) => new(ptr);
}