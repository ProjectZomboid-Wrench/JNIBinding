using System.Runtime.InteropServices;
using JNIBinding.Bindings.Native.Types;
using JNIBinding.Exceptions;

namespace JNIBinding.Bindings.Decorated;

public class JavaClass
{
    private readonly JNIEnv _env;
    private readonly JavaRuntime _runtime;
    
    public _JClass Value { get; }
    public string ClassName { get; init; }
    
    public JavaClass(JNIEnv env, ref readonly _JClass jniRef, string className, JavaRuntime runtime)
    {
        _env = env;
        _runtime = runtime;
        Value = jniRef;
        ClassName = className;
    }

    public JavaValue NewArray(int size)
    {
        _JObjectArray array = _env.NewObjectArray(size, Value, new _JObject());
        _env.CheckJavaExceptionAndThrow();

        return new JavaValue(_env, new _JValue(array), _runtime);
    }

    public JavaFunction GetConstructor(string signature)
    {
        var methodId = _env.GetMethodId(Value, "<init>", signature);
        if (methodId.IsNull)
            throw new ArgumentException($"Constructor not found: {ClassName}{signature}");
        return new JavaFunction(_env, methodId, true, this, null, signature, "<init>", _runtime);
    }

    public JavaFunction GetStaticMethod(string name, string signature)
    {
        var methodId = _env.GetStaticMethodId(Value, name, signature);
        if (methodId.IsNull)
            throw new ArgumentException($"Static method not found: {ClassName}.{name}.{signature}");
        return new JavaFunction(_env, methodId, false, this, null, signature, name, _runtime);
    }

    public JavaField GetStaticField(string name, string signature)
    {
        var fieldId = _env.GetStaticFieldID(Value, name, signature);
        if (fieldId.IsNull)
            throw new ArgumentException($"Static field not found: {ClassName}.{name}.{signature}");
        return new JavaField(_env, null, signature, fieldId, this, name, _runtime);
    }

    public RegisterNativesHelper BeginRegisterNatives()
    {
        return new RegisterNativesHelper(_env, this);
    }

    public void UnregisterNatives() => _env.UnregisterNatives(Value);

    /// <summary>Raises a pending Java exception of this class; it is thrown to Java when the native method returns.</summary>
    public unsafe void ThrowNew(string message)
    {
        var utf8 = Marshal.StringToCoTaskMemUTF8(message);
        int result;
        try
        {
            result = _env.ThrowNew(Value, (byte*)utf8);
        }
        finally
        {
            Marshal.FreeCoTaskMem(utf8);
        }
        if (result != 0)
            throw new JNIException($"ThrowNew failed (code: {result}): {ClassName}: {message}");
    }

    public override string ToString() => $"{nameof(JavaClass)}({ClassName})";

    /// <summary>
    /// Get the underlying JNI _JClass handle for this JavaClass
    /// </summary>
    public static implicit operator _JClass(JavaClass cls) => cls.Value;
}