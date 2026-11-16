namespace JNIBinding.Bindings.Native.Types;

public readonly struct JFloatArray(IntPtr value)
{
    public readonly IntPtr Value = value;
    
    public bool IsNull => Value == IntPtr.Zero;
    public override string ToString() => $"{nameof(JFloatArray)}[{Value:X16}]";
    
    public static implicit operator IntPtr(JFloatArray jniRef) => jniRef.Value;
}