namespace JNIBinding.Bindings.Native.Types;

public readonly struct _JNIWeakRef(IntPtr value)
{
    public readonly IntPtr Value;
    
    public bool IsNull => Value == IntPtr.Zero;
    public override string ToString() => $"{nameof(_JNIWeakRef)}[{Value:X16}]";
    
    public static implicit operator IntPtr(_JNIWeakRef jniRef) => jniRef.Value;
}