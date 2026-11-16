using JNIBinding.Bindings.Native.Types;

namespace JNIBinding;

/// <summary>
/// Converts between Java strings/boxed primitives and .NET values. Class refs and method ids are cached as global refs
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

    /// <summary>
    /// Boxes a .NET value as its Java counterpart: string, bool, sbyte/byte (as Byte), char, short, int, long, float
    /// and double. Returns a new local ref the caller owns; null becomes a null ref.
    /// </summary>
    public static _JObject Box(JNIEnv env, object? value)
    {
        if (value is null)
            return _JObject.Null;
        if (value is string s)
            return (_JObject)env.AsJString(s);

        var c = Get(env);
        var (cls, valueOf, arg) = value switch
        {
            bool b => (c.Boolean, c.BooleanValueOf, new _JValue(new _JBoolean(b))),
            sbyte sb => (c.Byte, c.ByteValueOf, new _JValue(unchecked((byte)sb))),
            byte by => (c.Byte, c.ByteValueOf, new _JValue(by)),
            char ch => (c.Character, c.CharacterValueOf, new _JValue((ushort)ch)),
            short sh => (c.Short, c.ShortValueOf, new _JValue(sh)),
            int i => (c.Integer, c.IntegerValueOf, new _JValue(i)),
            long l => (c.Long, c.LongValueOf, new _JValue(l)),
            float f => (c.Float, c.FloatValueOf, new _JValue(f)),
            double d => (c.Double, c.DoubleValueOf, new _JValue(d)),
            _ => throw new ArgumentException($"{value.GetType()} has no Java boxed counterpart", nameof(value)),
        };
        _JValue* args = stackalloc _JValue[] { arg };
        return env.CallStaticObjectMethod(cls, valueOf, args);
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
        public readonly _JMethodID BooleanValueOf, ByteValueOf, CharacterValueOf, ShortValueOf, IntegerValueOf,
            LongValueOf, FloatValueOf, DoubleValueOf;

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

            BooleanValueOf = env.GetStaticMethodId(Boolean, "valueOf", "(Z)Ljava/lang/Boolean;");
            ByteValueOf = env.GetStaticMethodId(Byte, "valueOf", "(B)Ljava/lang/Byte;");
            CharacterValueOf = env.GetStaticMethodId(Character, "valueOf", "(C)Ljava/lang/Character;");
            ShortValueOf = env.GetStaticMethodId(Short, "valueOf", "(S)Ljava/lang/Short;");
            IntegerValueOf = env.GetStaticMethodId(Integer, "valueOf", "(I)Ljava/lang/Integer;");
            LongValueOf = env.GetStaticMethodId(Long, "valueOf", "(J)Ljava/lang/Long;");
            FloatValueOf = env.GetStaticMethodId(Float, "valueOf", "(F)Ljava/lang/Float;");
            DoubleValueOf = env.GetStaticMethodId(Double, "valueOf", "(D)Ljava/lang/Double;");

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
