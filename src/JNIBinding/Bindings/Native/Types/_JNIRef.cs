using System.Runtime.InteropServices;

namespace JNIBinding.Bindings.Native.Types;

[StructLayout(LayoutKind.Sequential)]
public readonly struct _JNIRef(_JNIEnv env, IntPtr jniPtr)
{
    public readonly IntPtr Value = jniPtr;
    public readonly _JNIEnv Env = env;
    
    public bool IsNull => Value == IntPtr.Zero;
    public override string ToString() => $"{nameof(_JNIRef)}[{Value:X16}]";
    
    public static implicit operator IntPtr(_JNIRef jniRef) => jniRef.Value;
}