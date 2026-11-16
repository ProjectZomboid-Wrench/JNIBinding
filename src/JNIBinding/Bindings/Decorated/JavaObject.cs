using JNIBinding.Bindings.Native.Types;

namespace JNIBinding.Bindings.Decorated;

public class JavaObject
{
    public readonly _JObject Value;
    
    private readonly JNIEnv _env;
    private readonly JavaClass _class;
    private readonly JavaRuntime _runtime;

    public JavaObject(JNIEnv env, _JObject jniRef, JavaClass jClass, JavaRuntime runtime)
    {
        Value = jniRef;
        _env = env;
        _class = jClass;
        _runtime = runtime;
    }

    public JavaFunction GetInstanceMethod(string name, string signature)
    {
        var methodId = _env.GetMethodId(clsPtr: _class.Value, methodName: name, methodSig: signature);
        
        if (methodId.IsNull)
            throw new ArgumentException(message: $"Method not found: {_class.ClassName}.{name}.{signature}");

        return new JavaFunction(
            env: _env,
            jniId: methodId,
            isConstructor: false,
            @class: _class,
            instance: this,
            signature: signature,
            methodName: name,
            runtime: _runtime
        );
    }

    public JavaField GetInstanceField(string name, string signature)
    {
        var fieldId = _env.GetFieldID(_class.Value, name, signature);
        if (fieldId.IsNull)
            throw new ArgumentException($"Field not found: {_class.ClassName}.{name}.{signature}");
        return new JavaField(_env, this, signature, fieldId, _class, name, _runtime);
    }

    public void SetArrayElement(int index, _JObject value)
    {
        _env.SetObjectArrayElement(Value.AsObjectArray(), index, value);
        _env.CheckJavaExceptionAndThrow();
    }

    public void DeleteGlobalRef() => _env.DeleteGlobalRef(Value);

    public override string ToString() => $"{nameof(JavaObject)}({Value}: {_class.ClassName})";
}