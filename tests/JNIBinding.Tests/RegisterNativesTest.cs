using System;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using JNIBinding.Bindings.Native.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JNIBinding.Tests;

[TestClass]
[TestSubject(typeof(RegisterNativesHelper))]
public unsafe class RegisterNativesTest
{
    private readonly JavaRuntime _runtime = TestJvm.Bootstrap();

    [UnmanagedCallersOnly]
    private static int Add(IntPtr env, IntPtr cls, int a, int b) => a + b;

    [UnmanagedCallersOnly]
    private static void Noop(IntPtr env, IntPtr cls) { }

    [TestMethod]
    public void RegisterNatives_Java_Calls_Into_Dotnet()
    {
        var cls = _runtime.FindClass("NativeTarget");
        cls.BeginRegisterNatives()
            .Add("add", "(II)I", (delegate* unmanaged<IntPtr, IntPtr, int, int, int>)&Add)
            .Complete();

        var env = _runtime.Env;
        var callAdd = env.GetStaticMethodId(cls, "callAdd", "(II)I");
        _JValue* args = stackalloc _JValue[] { new _JValue(2), new _JValue(40) };

        Assert.AreEqual(42, env.CallStaticIntMethod(cls, callAdd, args));
    }

    [TestMethod]
    public void RegisterNatives_Unknown_Method_Throws_And_Clears_Exception()
    {
        var cls = _runtime.FindClass("NativeTarget");

        Assert.ThrowsExactly<JavaThrowable>(() => cls.BeginRegisterNatives()
            .Add("missing", "()V", (delegate* unmanaged<IntPtr, IntPtr, void>)&Noop)
            .Complete());
        Assert.IsTrue(_runtime.Env.ExceptionOccurred().IsNull);
    }
}
