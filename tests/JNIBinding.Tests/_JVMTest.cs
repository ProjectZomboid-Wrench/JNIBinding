using System;
using JetBrains.Annotations;
using JNIBinding.Bindings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JNIBinding.Tests;

[TestClass]
[TestSubject(typeof(JVM))]
public class _JVMTest
{
    private readonly IVMRef _bootstrapper;
    private readonly JavaRuntime _runtime;

    public _JVMTest()
    {
        _bootstrapper = TestJvm.Library;
        _runtime = TestJvm.Bootstrap();
    }

    [TestMethod]
    public void JVM_Can_CreateOrGetCreated()
    {
        var vm = JVM.CreateOrGetCreated(_bootstrapper, ["-Xcheck:jni"]);
        Console.WriteLine($"VM: {vm}");

        Assert.IsFalse(vm.Handle.IsNull);
        Assert.IsNotNull(vm.GetEnv());
    }

    [TestMethod]
    public void JVM_GetCreated_Returns_Running_VM()
    {
        var vm = JVM.GetCreated(_bootstrapper);

        Assert.IsNotNull(vm);
        Assert.AreEqual(_runtime.VM.Handle.Value, vm.Handle.Value);
    }

    [TestMethod]
    public void JVM_Can_GetVersion()
    {
        var version = _runtime.Env.GetVersion();
        Console.WriteLine($"0x{version:X8}");

        Assert.IsGreaterThanOrEqualTo(0x00010006, version);
    }

    [TestMethod]
    public void FindSystemClass_Loads_Classpath_Class()
    {
        var cls = _runtime.FindSystemClass("NativeTarget");

        Assert.IsFalse(cls.Value.IsNull);
    }

    [TestMethod]
    public void FindSystemClass_Unknown_Class_Throws_And_Clears_Exception()
    {
        Assert.ThrowsExactly<JavaThrowable>(() => _runtime.FindSystemClass("does.not.Exist"));
        Assert.IsTrue(_runtime.Env.ExceptionOccurred().IsNull);
    }
}
