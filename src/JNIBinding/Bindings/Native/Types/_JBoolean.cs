namespace JNIBinding.Bindings.Native.Types;

public enum JBoolean : System.Byte
{
    JNI_FALSE = 0,
    JNI_TRUE = 1,
}

public readonly struct _JBoolean(JBoolean value)
{
    public readonly JBoolean Value = value;

    public static _JBoolean True => new(JBoolean.JNI_TRUE);
    public static _JBoolean False => new(JBoolean.JNI_FALSE);

    public _JBoolean(byte value) : this(FromByte(value)) { }
    
    public _JBoolean(bool value) : this(FromBool(value)) { }

    public byte AsByte() => (byte)Value;
    public bool AsBool() => Value == JBoolean.JNI_TRUE;
    
    public static bool AsBoolFromByte(byte value) => value == 1;
    public static bool AsBoolFromJBool(JBoolean value) => value == JBoolean.JNI_TRUE;
    
    public static JBoolean FromByte(byte value) => (value == 1) ? JBoolean.JNI_TRUE : JBoolean.JNI_FALSE;
    public static JBoolean FromBool(bool value) => (value) ? JBoolean.JNI_TRUE : JBoolean.JNI_FALSE;

    public static implicit operator _JBoolean(JBoolean value) => new(value);
}