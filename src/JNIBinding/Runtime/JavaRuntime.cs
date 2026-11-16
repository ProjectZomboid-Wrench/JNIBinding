using JNIBinding.Bindings;
using JNIBinding.Bindings.Decorated;
using JNIBinding.Bindings.Native.Types;
using JNIBinding.Exceptions;

namespace JNIBinding;

/// <summary>
/// Decorated API bound to one thread's <see cref="JNIEnv"/>. Don't share an instance across threads;
/// use <see cref="ForCurrentThread"/> to get one for another thread.
/// </summary>
public class JavaRuntime(JVM vm, JNIEnv env)
{
    private readonly JNIEnv _env = env;

    public JVM VM { get; } = vm;

    public JNIEnv Env => _env;

    public void PushLocalFrame(int capacity) => _env.PushLocalFrame(capacity);

    public void PopLocalFrame() => _env.PopLocalFrame(_JObject.Null);

    public _JString AllocateStringAnsi(string s) => _env.NewStringAnsi(s);

    public JavaClass FindClass(string className)
    {
        if (className.Contains("/"))
            throw new ArgumentException("Use dot notation rather than JNI slashed notation");

        var cls = _env.FindClass(className.Replace(".", "/"));
        if (cls.IsNull)
            throw new JNIClassNotFoundException(className);

        return new JavaClass(_env, ref cls, className, this);
    }

    /// <summary>
    /// Loads a class through the system class loader. Use this instead of <see cref="FindClass"/> when entered
    /// from FFM or other non-JNI paths, where FindClass resolves against a JDK-internal caller's loader.
    /// </summary>
    public unsafe JavaClass FindSystemClass(string className)
    {
        if (className.Contains("/"))
            throw new ArgumentException("Use dot notation rather than JNI slashed notation");

        var loaderCls = _env.FindClass("java/lang/ClassLoader");
        var getSystemLoader = _env.GetStaticMethodId(loaderCls, "getSystemClassLoader", "()Ljava/lang/ClassLoader;");
        var loadClass = _env.GetMethodId(loaderCls, "loadClass", "(Ljava/lang/String;)Ljava/lang/Class;");
        var loader = _env.CallStaticObjectMethod(loaderCls, getSystemLoader, null);

        var name = _env.AsJString(className);
        _JValue* args = stackalloc _JValue[] { new _JValue((_JObject)name) };
        var cls = _env.CallObjectMethodA(loader, loadClass, args).AsClass();
        _env.CheckJavaExceptionAndThrow();

        _env.DeleteLocalRef((_JObject)name);
        _env.DeleteLocalRef(loader);
        _env.DeleteLocalRef(loaderCls);
        if (cls.IsNull)
            throw new JNIClassNotFoundException(className);

        return new JavaClass(_env, ref cls, className, this);
    }

    public JavaRuntime ForCurrentThread() => new(VM, VM.GetOrAttachEnv());

    /// <summary>Creates the JVM, or joins the one already running in this process.</summary>
    public static JavaRuntime Bootstrap(IVMRef bootstrapper, params string[] jvmArgs)
    {
        bootstrapper.LoadLibrary();
        var vm = JVM.CreateOrGetCreated(bootstrapper, [..jvmArgs, "-Xcheck:jni", "-verbose:jni"]);
        return new JavaRuntime(vm, vm.GetOrAttachEnv());
    }

    /// <summary>Wraps a VM handed to native code by the JVM, e.g. the JavaVM* passed to JNI_OnLoad.</summary>
    public static JavaRuntime FromExisting(_JVM handle)
    {
        var vm = new JVM(handle);
        return new JavaRuntime(vm, vm.GetOrAttachEnv());
    }
}
