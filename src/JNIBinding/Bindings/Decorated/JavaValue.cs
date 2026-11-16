using JNIBinding.Bindings.Native.Types;

namespace JNIBinding.Bindings.Decorated;

public class JavaValue
{
    private readonly JavaRuntime _runtime;
    private readonly JNIEnv _env;
    public readonly _JValue Value;

    public JavaValue(JNIEnv env, _JValue value, JavaRuntime runtime)
    {
        _env = env;
        Value = value;
        _runtime = runtime;
    }

    public bool IsNull() => Value.Ref.IsNull;

    public string FetchString()
    {
        _notNullGuard();
        return _env.GetText(Value.Ref.AsString());
    }

    public unsafe IntPtr FetchDirectBufferAccess()
    {
        _notNullGuard();
        return new IntPtr(_env.GetDirectBufferAddress(Value.Ref));
    }

    public JavaValue MakeGlobal()
    {
        var globalRef = _env.NewGlobalRef(Value.Ref);
        return new JavaValue(_env, new _JValue(globalRef), _runtime);
    }

    public unsafe JavaObject FetchObject()
    {
        _notNullGuard();

        var clsObject = _env.FindClass("java/lang/Object");
        var getClass = _env.GetMethodId(clsObject, "getClass", "()Ljava/lang/Class;");
        var cls = _env.CallObjectMethodA(Value.Ref, getClass, null).AsClass();
        _env.CheckJavaExceptionAndThrow();

        var clsClass = _env.FindClass("java/lang/Class");
        _env.CheckJavaExceptionAndThrow();
        var getName = _env.GetMethodId(clsClass, "getName", "()Ljava/lang/String;");
        var clsName = _env.CallObjectMethod(cls, getName, null).AsString();
        _env.CheckJavaExceptionAndThrow();

        return new JavaObject(
            env: _env,
            jniRef: Value.Ref,
            jClass: new JavaClass(_env, ref cls, _env.GetText(clsName), _runtime),
            _runtime
        );
    }

    private void _notNullGuard()
    {
        if (IsNull())
            throw new NullReferenceException();
    }

    public void Throw()
    {
        _notNullGuard();
        _env.Throw(Value.Ref.AsThrowable());
    }

    public override string ToString() => $"{nameof(JavaValue)}({Value})";
}