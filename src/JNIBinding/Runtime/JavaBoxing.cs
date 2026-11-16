using JNIBinding.Bindings.Native.Types;

namespace JNIBinding;

/// <summary>
/// Converts Java strings and boxed primitives to .NET values. Class refs and method ids are cached as global refs
/// on first use and shared by every thread, since a process hosts a single JVM.
/// </summary>
public static unsafe class JavaBoxing
{
    private static readonly Lock InitLock = new();
    private static Cache? _cache;

    /// <summary>
    /// Unwraps null, <c>String</c>, <c>Boolean</c>, <c>Byte</c> (as <see cref="sbyte"/>), <c>Character</c>,
    /// <c>Short</c>, <c>Integer</c>, <c>Long</c>, <c>Float</c> and <c>Double</c>. Returns false for any other object.
    /// The caller still owns <paramref name="obj"/>'s reference.
    /// </summary>
    public static bool TryUnbox(JNIEnv env, _JObject obj, out object? value)
    {
        if (obj.IsNull)
        {
            value = null;
            return true;
        }

        var c = Get(env);
        // Ordered by how often Lua hands them over: Kahlua numbers are Doubles.
        if (env.IsInstanceOf(obj, c.Double))
            value = env.CallDoubleMethod(obj, c.DoubleValue, null);
        else if (env.IsInstanceOf(obj, c.String))
            value = env.AsString(obj.AsString());
        else if (env.IsInstanceOf(obj, c.Boolean))
            value = env.CallBooleanMethod(obj, c.BooleanValue, (_JValue*)null).AsBool();
        else if (env.IsInstanceOf(obj, c.Integer))
            value = env.CallIntMethod(obj, c.IntValue, (_JValue*)null);
        else if (env.IsInstanceOf(obj, c.Long))
            value = env.CallLongMethod(obj, c.LongValue, null);
        else if (env.IsInstanceOf(obj, c.Float))
            value = env.CallFloatMethod(obj, c.FloatValue, null);
        else if (env.IsInstanceOf(obj, c.Short))
            value = env.CallShortMethod(obj, c.ShortValue, (_JValue*)null);
        else if (env.IsInstanceOf(obj, c.Byte))
            value = unchecked((sbyte)env.CallByteMethod(obj, c.ByteValue, null));
        else if (env.IsInstanceOf(obj, c.Character))
            value = (char)env.CallCharMethod(obj, c.CharValue, (_JValue*)null);
        else
        {
            value = null;
            return false;
        }
        return true;
    }

    /// <summary>The object's Java class name, e.g. <c>java.lang.StringBuilder</c>.</summary>
    public static string GetClassName(JNIEnv env, _JObject obj)
    {
        var c = Get(env);
        var cls = env.GetObjectClass(obj);
        var name = env.CallObjectMethod(cls, c.GetName, null);
        try
        {
            return env.AsString(name.AsString());
        }
        finally
        {
            env.DeleteLocalRef(name);
            env.DeleteLocalRef(cls);
        }
    }

    /// <summary>Java's <c>String.valueOf(obj)</c>: <c>toString()</c>, or <c>"null"</c>.</summary>
    public static string ToJavaString(JNIEnv env, _JObject obj)
    {
        var c = Get(env);
        _JValue* args = stackalloc _JValue[] { new _JValue(obj) };
        var text = env.CallStaticObjectMethod(c.String, c.ValueOf, args);
        try
        {
            return env.AsString(text.AsString());
        }
        finally
        {
            env.DeleteLocalRef(text);
        }
    }

    private static Cache Get(JNIEnv env)
    {
        if (_cache is { } cache)
            return cache;
        lock (InitLock)
            return _cache ??= new Cache(env);
    }

    private sealed class Cache
    {
        public readonly _JClass String, Boolean, Byte, Character, Short, Integer, Long, Float, Double;
        public readonly _JMethodID BooleanValue, ByteValue, CharValue, ShortValue, IntValue, LongValue, FloatValue,
            DoubleValue, GetName, ValueOf;

        public Cache(JNIEnv env)
        {
            String = Global(env, "java/lang/String");
            Boolean = Global(env, "java/lang/Boolean");
            Byte = Global(env, "java/lang/Byte");
            Character = Global(env, "java/lang/Character");
            Short = Global(env, "java/lang/Short");
            Integer = Global(env, "java/lang/Integer");
            Long = Global(env, "java/lang/Long");
            Float = Global(env, "java/lang/Float");
            Double = Global(env, "java/lang/Double");

            BooleanValue = env.GetMethodId(Boolean, "booleanValue", "()Z");
            ByteValue = env.GetMethodId(Byte, "byteValue", "()B");
            CharValue = env.GetMethodId(Character, "charValue", "()C");
            ShortValue = env.GetMethodId(Short, "shortValue", "()S");
            IntValue = env.GetMethodId(Integer, "intValue", "()I");
            LongValue = env.GetMethodId(Long, "longValue", "()J");
            FloatValue = env.GetMethodId(Float, "floatValue", "()F");
            DoubleValue = env.GetMethodId(Double, "doubleValue", "()D");
            ValueOf = env.GetStaticMethodId(String, "valueOf", "(Ljava/lang/Object;)Ljava/lang/String;");

            var classClass = env.FindClass("java/lang/Class");
            GetName = env.GetMethodId(classClass, "getName", "()Ljava/lang/String;");
            env.DeleteLocalRef(classClass);
        }

        private static _JClass Global(JNIEnv env, string name)
        {
            var local = env.FindClass(name);
            var global = env.NewGlobalRef(local).AsClass();
            env.DeleteLocalRef(local);
            return global;
        }
    }
}
