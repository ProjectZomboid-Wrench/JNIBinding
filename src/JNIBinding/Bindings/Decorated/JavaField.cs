using JNIBinding.Bindings.Extensions;
using JNIBinding.Bindings.Native.Types;

namespace JNIBinding.Bindings.Decorated;

public class JavaField
{
    private readonly JNIEnv _env;
    private readonly JavaRuntime _runtime;
    
    private readonly JavaObject? _instance;
    private readonly string _signature;
    private readonly JavaClass _class;

    public string FieldName { get; init; }
    public _JFieldID FieldID { get; init; }

    public JavaField(JNIEnv env, JavaObject instance, string signature, _JFieldID jniId, JavaClass jClass,
        string fieldName, JavaRuntime runtime)
    {
        _env = env;
        _instance = instance;
        _signature = signature;
        _class = jClass;
        FieldName = fieldName;
        _runtime = runtime;
        FieldID = jniId;

    }

    public JavaValue GetValue()
    {
        var value = InternalGetValue();
        return new JavaValue(_env, value, _runtime);
    }

    private _JValue InternalGetValue()
    {
        if (_instance == null)
            return StaticCalls.Get(_signature[0]).Invoke(_env, _class.Value, FieldID);
        return InstanceCalls.Get(_signature[0]).Invoke(_env, _instance.Value, FieldID);
    }

    public override string ToString()
    {
        return $"{nameof(JavaField)}({FieldName}: {_signature})";
    }

    private delegate _JValue StaticCall(JNIEnv env, _JClass clsHnd, _JFieldID jFieldId);

    private delegate _JValue InstanceCall(JNIEnv env, _JObject instance, _JFieldID jFieldId);

    private static readonly Dictionary<char, StaticCall> StaticCalls = new();
    private static readonly Dictionary<char, InstanceCall> InstanceCalls = new();

    static JavaField()
    {
        StaticCalls['Z'] = (env, cls, id) => new _JValue(env.GetStaticBooleanField(cls, id));
        StaticCalls['B'] = (env, cls, id) => new _JValue(env.GetStaticByteField(cls, id));
        StaticCalls['C'] = (env, cls, id) => new _JValue(env.GetStaticCharField(cls, id));
        StaticCalls['S'] = (env, cls, id) => new _JValue(env.GetStaticShortField(cls, id));
        StaticCalls['I'] = (env, cls, id) => new _JValue(env.GetStaticIntField(cls, id));
        StaticCalls['J'] = (env, cls, id) => new _JValue(env.GetStaticLongField(cls, id));
        StaticCalls['F'] = (env, cls, id) => new _JValue(env.GetStaticFloatField(cls, id));
        StaticCalls['D'] = (env, cls, id) => new _JValue(env.GetStaticDoubleField(cls, id));
        StaticCalls['L'] = (env, cls, id) => new _JValue(env.GetStaticObjectField(cls, id));
        StaticCalls['['] = (env, cls, id) => new _JValue(env.GetStaticObjectField(cls, id));

        InstanceCalls['Z'] = (env, inst, id) => new _JValue(env.GetBooleanField(inst, id));
        InstanceCalls['B'] = (env, inst, id) => new _JValue(env.GetBooleanField(inst, id));
        InstanceCalls['C'] = (env, inst, id) => new _JValue(env.GetCharField(inst, id));
        InstanceCalls['S'] = (env, inst, id) => new _JValue(env.GetShortField(inst, id));
        InstanceCalls['I'] = (env, inst, id) => new _JValue(env.GetIntField(inst, id));
        InstanceCalls['J'] = (env, inst, id) => new _JValue(env.GetLongField(inst, id));
        InstanceCalls['F'] = (env, inst, id) => new _JValue(env.GetFloatField(inst, id));
        InstanceCalls['D'] = (env, inst, id) => new _JValue(env.GetDoubleField(inst, id));
        InstanceCalls['L'] = (env, inst, id) => new _JValue(env.GetObjectField(inst, id));
        InstanceCalls['['] = (env, inst, id) => new _JValue(env.GetObjectField(inst, id));
    }
}