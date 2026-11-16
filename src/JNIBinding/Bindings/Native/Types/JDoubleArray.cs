namespace JNIBinding.Bindings.Native.Types;

public readonly struct JDoubleArray(IntPtr value)
{
    public readonly IntPtr Value = value;
    
    public bool IsNull => Value == IntPtr.Zero;
    public override string ToString() => $"{nameof(JDoubleArray)}[{Value:X16}]";
    
    public static implicit operator IntPtr(JDoubleArray jniRef) => jniRef.Value;
}