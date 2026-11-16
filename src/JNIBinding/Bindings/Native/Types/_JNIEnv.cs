using System.Runtime.InteropServices;

namespace JNIBinding.Bindings.Native.Types;

// Primitive types for JNI interfacing, they track the minimal amount of information.
// System.Char is not blittable, JChar is
using _JSize = int;

[StructLayout(LayoutKind.Sequential)]
public readonly struct _JNIEnv(IntPtr envPtr)
{
    public readonly IntPtr Value = envPtr;

    public bool IsNull => Value == IntPtr.Zero;
    public override string ToString() => $"&{nameof(_JNIEnv)}[0x{Value:X16}]";

    public static implicit operator IntPtr(_JNIEnv jniRef) => jniRef.Value;

    public unsafe void* ToPointer() => Value.ToPointer();
}