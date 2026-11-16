using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JNIBinding.Exceptions;

namespace JNIBinding.Tests;

[TestClass]
[TestSubject(typeof(JNIEnvExtensions))]
public class ExceptionTest
{
    private readonly JavaRuntime _runtime = TestJvm.Bootstrap();

    [TestMethod]
    public void ThrowNew_Is_Surfaced_With_Message_And_Cleared()
    {
        _runtime.FindClass("java.lang.IllegalStateException").ThrowNew("héllo wörld");

        var ex = Assert.ThrowsExactly<JavaThrowable>(() => _runtime.Env.CheckJavaExceptionAndThrow());

        StringAssert.Contains(ex.Message, "java.lang.IllegalStateException: héllo wörld");
        Assert.IsTrue(_runtime.Env.ExceptionOccurred().IsNull);
    }

    [TestMethod]
    public void CheckJavaExceptionAndThrow_Without_Pending_Exception_Returns_False()
    {
        Assert.IsFalse(_runtime.Env.CheckJavaExceptionAndThrow());
    }
}
