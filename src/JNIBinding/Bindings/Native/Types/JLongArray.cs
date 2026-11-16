namespace JNIBinding.Bindings.Native.Types;

public readonly struct JLongArray(IntPtr value)
{
    public readonly IntPtr Value = value;
    
    public bool IsNull => Value == IntPtr.Zero;
    public override string ToString() => $"{nameof(JLongArray)}[{Value:X16}]";
    
    public static implicit operator IntPtr(JLongArray jniRef) => jniRef.Value;
}