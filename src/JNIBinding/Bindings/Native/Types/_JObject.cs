using System.Runtime.InteropServices;

namespace JNIBinding.Bindings.Native.Types;

public static class _JObjectExtensions
{
    /// <summary>
    /// Create a new, effectively null, _JObject handle pointing at nothing
    /// </summary>
    /// <returns></returns>
    public static _JObject Null() => new(IntPtr.Zero);
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct _JObject(IntPtr value)
{
    public readonly IntPtr Value = value;
    public static readonly _JObject Null = new(IntPtr.Zero);
    
    public bool IsNull => Value == IntPtr.Zero;
    public override string ToString() => $"{nameof(_JObject)}[{Value:X16}]";
    
    public static implicit operator IntPtr(_JObject jniRef) => jniRef.Value;

    public _JObject(_JNIRef value) : this(value.Value)
    { }

    public _JClass AsClass() => new _JClass(Value);
    public _JThrowable AsThrowable() => new _JThrowable(Value);
    public _JString AsString() => new _JString(Value);
    public _JByteArray AsByteArray() => new _JByteArray(Value);
    public _JArray AsArray() => new _JArray(Value);
    public _JObjectArray AsObjectArray() => new _JObjectArray(Value);
    
    public static explicit operator _JObject(_JClass jRef) => new(jRef.Value);
    public static explicit operator _JObject(_JThrowable jRef) => new(jRef.Value);
    public static explicit operator _JObject(_JString jRef) => new(jRef.Value);
    
    public static explicit operator _JObject(_JArray jRef) => new(jRef.Value);
    public static explicit operator _JObject(_JBooleanArray jRef) => new(jRef.Value);
    public static explicit operator _JObject(_JByteArray jRef) => new(jRef.Value);
    public static explicit operator _JObject(_JCharArray jRef) => new(jRef.Value);
    public static explicit operator _JObject(_JShortArray jRef) => new(jRef.Value);
    public static explicit operator _JObject(_JFloatArray jRef) => new(jRef.Value);
    public static explicit operator _JObject(_JIntArray jRef) => new(jRef.Value);
    public static explicit operator _JObject(_JDoubleArray jRef) => new(jRef.Value);
    public static explicit operator _JObject(_JObjectArray jRef) => new(jRef.Value);
    public static explicit operator _JObject(_JLongArray jRef) => new(jRef.Value);

    public static implicit operator _JObject(IntPtr ptr) => new (ptr);
}