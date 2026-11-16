namespace JNIBinding.Bindings.Native.Types;

public readonly struct _JBooleanArray(IntPtr value)
{
    public readonly IntPtr Value = value;
    
    public bool IsNull => Value == IntPtr.Zero;
    public override string ToString() => $"{nameof(_JBooleanArray)}[{Value:X16}]";
    
    public static implicit operator IntPtr(_JBooleanArray jniRef) => jniRef.Value;
}