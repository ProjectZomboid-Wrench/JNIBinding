namespace JNIBinding.Bindings.Native.Types;

public readonly struct JIntArray(IntPtr value)
{
    public readonly IntPtr Value = value;
    
    public bool IsNull => Value == IntPtr.Zero;
    public override string ToString() => $"{nameof(JIntArray)}[{Value:X16}]";
    
    public static implicit operator IntPtr(JIntArray jniRef) => jniRef.Value;
}