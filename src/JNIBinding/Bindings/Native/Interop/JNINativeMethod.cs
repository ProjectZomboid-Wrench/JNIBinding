using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace JNIBinding.Bindings.Native;

/// <summary>
/// Used in RegisterNatives to describe native method name, signature & callback
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct JNINativeMethod
{
    public byte* name;             /* byte* */
    public byte* signature;        /* byte* */
    public void* fnPtr;            /* void* */   
}