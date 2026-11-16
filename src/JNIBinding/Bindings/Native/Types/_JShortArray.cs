namespace JNIBinding.Bindings.Native.Types;

public readonly struct _JShortArray(IntPtr value)
{
    public readonly IntPtr Value = value;
    
    public bool IsNull => Value == IntPtr.Zero;
    public override string ToString() => $"{nameof(_JShortArray)}[{Value:X16}]";
    
    public static implicit operator IntPtr(_JShortArray jniRef) => jniRef.Value;
}