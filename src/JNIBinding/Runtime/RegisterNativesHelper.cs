using System.Runtime.InteropServices;
using JNIBinding.Bindings.Decorated;
using JNIBinding.Bindings.Native;
using JNIBinding.Exceptions;

namespace JNIBinding;

/// <summary>
/// Binds Java <c>native</c> methods on a class to .NET function pointers.
/// </summary>
/// <example>
/// <code>
/// [UnmanagedCallersOnly]
/// static int Add(IntPtr env, IntPtr cls, int a, int b) => a + b;
///
/// javaClass.BeginRegisterNatives()
///     .Add("add", "(II)I", (delegate* unmanaged&lt;IntPtr, IntPtr, int, int, int&gt;)&amp;Add)
///     .Complete();
/// </code>
/// </example>
public sealed unsafe class RegisterNativesHelper(JNIEnv env, JavaClass classHnd)
{
    private readonly List<(string Name, string Signature, IntPtr Fn)> _methods = [];

    /// <param name="name">The Java method name.</param>
    /// <param name="signature">The JNI method descriptor, e.g. <c>(II)I</c>.</param>
    /// <param name="fn">
    /// Pointer to a static <c>[UnmanagedCallersOnly]</c> method whose first two parameters are the
    /// <c>JNIEnv*</c> and the <c>jclass</c> (static) or <c>jobject</c> (instance), followed by the Java parameters.
    /// </param>
    public RegisterNativesHelper Add(string name, string signature, void* fn)
    {
        if (fn == null)
            throw new ArgumentNullException(nameof(fn));
        _methods.Add((name, signature, (IntPtr)fn));
        return this;
    }

    public void Complete()
    {
        var count = _methods.Count;
        var natives = (JNINativeMethod*)NativeMemory.AllocZeroed((nuint)Math.Max(count, 1), (nuint)sizeof(JNINativeMethod));
        try
        {
            for (var i = 0; i < count; i++)
            {
                natives[i].name = (byte*)Marshal.StringToCoTaskMemUTF8(_methods[i].Name);
                natives[i].signature = (byte*)Marshal.StringToCoTaskMemUTF8(_methods[i].Signature);
                natives[i].fnPtr = (void*)_methods[i].Fn;
            }

            var result = (int)env.RegisterNatives(classHnd, natives, count);
            env.SurfaceException();
            if (result != 0)
                throw new JNIException($"RegisterNatives failed for {classHnd} (code: {result})");
        }
        finally
        {
            // The JVM resolves name/signature during the call and doesn't keep the pointers.
            for (var i = 0; i < count; i++)
            {
                Marshal.FreeCoTaskMem((IntPtr)natives[i].name);
                Marshal.FreeCoTaskMem((IntPtr)natives[i].signature);
            }
            NativeMemory.Free(natives);
        }
    }
}
