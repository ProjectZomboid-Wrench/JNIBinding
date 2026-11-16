using System.Runtime.InteropServices;
using System.Text;
using JNIBinding.Bindings.Native.Types;
using JNIBinding.Exceptions;

namespace JNIBinding;

public static class JNIEnvExtensions
{
    public static _JString NewStringAnsi(this JNIEnv env, string text) => AsJString(env, text);

    public static unsafe _JString AsJString(this JNIEnv env, string text)
    {
        var bytes = Marshal.StringToCoTaskMemUTF8(text);
        try
        {
            return env.NewStringUTF((byte*)bytes);
        }
        finally
        {
            Marshal.FreeCoTaskMem(bytes);
        }
    }

    [Obsolete("Use AsString instead")]
    public static string GetText(this JNIEnv env, _JString s) => AsString(env, s);

    public static unsafe string AsString(this JNIEnv env, _JString s)
    {
        var utf8 = env.AsJString("UTF-8");
        var clsStr = env.FindClass("java/lang/String");
        var methodBytes = env.GetMethodId(clsStr, "getBytes", "(Ljava/lang/String;)[B");
        _JByteArray jbyteArray;
        fixed (_JValue* pargs = new[] { new _JValue(utf8) })
            jbyteArray = env.CallObjectMethodA((_JObject)s, methodBytes, pargs).AsByteArray();
        env.DeleteLocalRef((_JObject)utf8);
        var len = env.GetArrayLength(jbyteArray);
        byte[] byteArray = new byte[len];
        fixed (byte* b = byteArray)
            env.GetByteArrayRegion(jbyteArray, 0, len, b);
        env.SurfaceException();

        return Encoding.UTF8.GetString(byteArray);
    }

    public static void SurfaceException(this JNIEnv env)
    {
        var ex = env.ExceptionOccurred();
        if (ex.IsNull)
            return;
        env.ExceptionClear();

        string? trace;
        env.PushLocalFrame(32);
        try
        {
            trace = ReadStackTrace(env, ex);
        }
        catch (JavaThrowable)
        {
            trace = null;
        }
        finally
        {
            env.PopLocalFrame(_JObject.Null);
        }

        throw new JavaThrowable($"Surfaced Java Exception: {trace ?? "<stack trace unavailable>"}");
    }

    private static unsafe string? ReadStackTrace(JNIEnv env, _JThrowable ex)
    {
        var clsBuffer = env.FindClass("java/io/ByteArrayOutputStream");
        var buffer = env.NewObject("java/io/ByteArrayOutputStream", "()V");
        if (ClearIfPending(env))
            return null;

        var encoding = env.AsJString("UTF-8");
        var writer = env.NewObject("java/io/PrintStream", "(Ljava/io/OutputStream;ZLjava/lang/String;)V",
            new _JValue(buffer), new _JValue(1), new _JValue(encoding));
        if (ClearIfPending(env))
            return null;

        var clsEx = env.FindClass("java/lang/Throwable");
        var exStack = env.GetMethodId(clsEx, "printStackTrace", "(Ljava/io/PrintStream;)V");
        fixed (_JValue* args = new[] { new _JValue(writer) })
            env.CallVoidMethodA((_JObject)ex, exStack, args);
        if (ClearIfPending(env))
            return null;

        var bufToArray = env.GetMethodId(clsBuffer, "toByteArray", "()[B");
        var traceBytes = env.CallObjectMethodA(buffer, bufToArray, null).AsByteArray();
        if (ClearIfPending(env))
            return null;

        var length = env.GetArrayLength(traceBytes);
        var bytes = new byte[length];
        fixed (byte* b = bytes)
            env.GetByteArrayRegion(traceBytes, 0, length, b);
        return Encoding.UTF8.GetString(bytes);
    }

    private static bool ClearIfPending(JNIEnv env)
    {
        if (env.Functions.ExceptionCheck(env.EnvHandle) == 0)
            return false;
        env.ExceptionClear();
        return true;
    }

    public static unsafe _JObject NewObject(this JNIEnv env, string jniClassName, string constructorSignature,
        params _JValue[] args)
    {
        var cls = env.FindClass(jniClassName);
        var ctor = env.GetMethodId(cls, "<init>", constructorSignature);
        fixed (_JValue* pargs = args)
            return env.NewObjectA(cls, ctor, pargs);
    }
}