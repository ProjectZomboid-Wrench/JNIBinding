using JNIBinding.Bindings.Native.Types;
using _jtype = JNIBinding.Bindings.Native.Types._JTypeInfo;

namespace JNIBinding.Bindings.Decorated;

/// <summary>
/// Provides a wrapper on _JMethodID.
/// Includes metadata bout the function origin
/// </summary>
/// <remarks>
/// The bare minimum for this class is the _JMethod pointer
/// and the _JNIEnv handle. Everything else is metadata.
/// 
/// It can optionally hold data about the declaring class type and
/// the methodname/signature.
/// </remarks>
public class JavaFunction
{
    private readonly JNIEnv _env;
    private readonly _JMethodID _jniId;
    private readonly bool _isConstructor;
    private readonly JavaClass _class;
    private JavaObject? _object;
    private readonly string _signature;
    private readonly string _methodName;
    private readonly JavaRuntime _runtime;
    private readonly char _returnTypeRaw;

    private readonly _JTypeInfo _returnType;

    public JavaFunction(JNIEnv env, _JMethodID jniId, bool isConstructor, JavaClass @class, JavaObject? instance,
        string signature, string methodName, JavaRuntime runtime)
    {
        _env = env;
        _jniId = jniId;
        _isConstructor = isConstructor;
        _class = @class;
        _object = instance;
        _signature = signature;
        _methodName = methodName;
        _runtime = runtime;

        var bracket = _signature.LastIndexOf(')');
        if (bracket < 0)
            throw new Exception($"Invalid signature: {signature}");

        _returnType = _JType.From(_signature[bracket + 1]);
    }

    private unsafe delegate _JValue StaticCall(JNIEnv env, _JClass cls, _JMethodID methodId, _JValue* args);

    private unsafe delegate _JValue InstanceCall(JNIEnv env, _JObject instance, _JMethodID methodId, _JValue* args);
    
    public JavaValue Invoke(params _JValue[] args)
    {
        var result = InvokeInternal(args);
        _env.CheckJavaExceptionAndThrow();
        return new JavaValue(_env, result, _runtime);
    }

    private unsafe _JValue InvokeInternal(_JValue[] args)
    {
        fixed (_JValue* argPtr = args)
        {
            if (_isConstructor)
                return new _JValue(_env.NewObjectA(_class.Value, _jniId, argPtr));

            if (_object != null)
                return instanceCalls[_returnType].Invoke(_env, _object.Value, _jniId, argPtr);

            return staticCalls[_returnType].Invoke(_env, _class.Value, _jniId, argPtr);
        }
    }

    public void ReleaseGlobalRefs() => _object?.DeleteGlobalRef();

    public override string ToString()
    {
        if (_isConstructor)
        {
            return $"{nameof(JavaFunction)}({_class.ClassName}{_signature}";
        }

        return $"{nameof(JavaFunction)}({_class.ClassName}.{_methodName}{_signature}";
    }

    private static readonly unsafe Dictionary<_JTypeInfo, StaticCall> staticCalls = new()
    {
        [_jtype.Boolean] = (env, cls, id, args) => new _JValue(env.CallStaticBooleanMethod(cls, id, args)),
        [_jtype.Byte] = (env, cls, id, args) => new _JValue(env.CallStaticByteMethod(cls, id, args)),
        [_jtype.Char] = (env, cls, id, args) => new _JValue(env.CallStaticCharMethod(cls, id, args)),
        [_jtype.Short] = (env, cls, id, args) => new _JValue(env.CallStaticShortMethod(cls, id, args)),
        [_jtype.Int] = (env, cls, id, args) => new _JValue(env.CallStaticIntMethod(cls, id, args)),
        [_jtype.Long] = (env, cls, id, args) => new _JValue(env.CallStaticLongMethod(cls, id, args)),
        [_jtype.Float] = (env, cls, id, args) => new _JValue(env.CallStaticFloatMethod(cls, id, args)),
        [_jtype.Double] = (env, cls, id, args) => new _JValue(env.CallStaticDoubleMethod(cls, id, args)),
        [_jtype.ClassName] = (env, cls, id, args) => new _JValue(env.CallStaticObjectMethod(cls, id, args)),
        [_jtype.Array] = (env, cls, id, args) => new _JValue(env.CallStaticObjectMethod(cls, id, args)),
        [_jtype.Void] = (env, cls, id, args) =>
        {
            env.CallStaticVoidMethod(cls, id, args);
            return new _JValue();
        },
    };

    private static readonly unsafe Dictionary<_JTypeInfo, InstanceCall> instanceCalls = new()
    {
        [_jtype.Boolean] = (env, inst, id, args) => new _JValue(env.CallBooleanMethod(inst, id, args)),
        [_jtype.Byte] = (env, inst, id, args) => new _JValue(env.CallByteMethod(inst, id, args)),
        [_jtype.Char] = (env, inst, id, args) => new _JValue(env.CallCharMethod(inst, id, args)),
        [_jtype.Short] = (env, inst, id, args) => new _JValue(env.CallShortMethod(inst, id, args)),
        [_jtype.Int] = (env, inst, id, args) => new _JValue(env.CallIntMethod(inst, id, args)),
        [_jtype.Long] = (env, inst, id, args) => new _JValue(env.CallLongMethod(inst, id, args)),
        [_jtype.Float] = (env, inst, id, args) => new _JValue(env.CallFloatMethod(inst, id, args)),
        [_jtype.Double] = (env, inst, id, args) => new _JValue(env.CallDoubleMethod(inst, id, args)),
        [_jtype.ClassName] = (env, inst, id, args) => new _JValue(env.CallObjectMethod(inst, id, args)),
        [_jtype.Array] = (env, inst, id, args) => new _JValue(env.CallObjectMethod(inst, id, args)),
        [_jtype.Void] = (env, inst, id, args) =>
        {
            env.CallVoidMethod(inst, id, args);
            return new _JValue();
        },
    };
}