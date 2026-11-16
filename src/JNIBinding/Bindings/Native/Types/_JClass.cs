using System.Diagnostics;
using System.Runtime.InteropServices;

namespace JNIBinding.Bindings.Native.Types;

/// <summary>
/// Handle to a JClass pointer in memory
/// </summary>
/// <remarks>
/// This is nothing more than a wrapper around a pointer.
/// </remarks>
/// <param name="value">IntPtr to JVM managed class</param>
[StructLayout(LayoutKind.Sequential)]
[DebuggerDisplay("{ToString}")]
public readonly struct _JClass(IntPtr value)
{
    /// <summary>
    /// Handle to the JClass instance
    /// </summary>
    public readonly IntPtr Value = value;
    
    /// <summary>
    /// Does this JClass handle point at anything?
    /// </summary>
    public bool IsNull => Value == IntPtr.Zero;
    
    public override string ToString() => $"{nameof(_JClass)}[{Value:X16}]";
    
    // JClass -> IntPtr
    public static implicit operator IntPtr(_JClass v) => v.Value;
    
    // JClass -> JObject
    public static implicit operator _JObject(_JClass v) => new(v.Value);
}