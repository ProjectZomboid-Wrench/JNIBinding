namespace JNIBinding.Bindings.Native.Types;

public readonly struct _JCharArray(IntPtr value)
{
    public readonly IntPtr Value = value;
    
    public bool IsNull => Value == IntPtr.Zero;
    public override string ToString() => $"{nameof(_JCharArray)}[{Value:X16}]";
    
    public static implicit operator IntPtr(_JCharArray jniRef) => jniRef.Value;
}