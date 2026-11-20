using System;
using JetBrains.Annotations;
using JNIBinding.Bindings.Native.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JNIBinding.Tests;

[TestClass]
[TestSubject(typeof(JavaBoxing))]
public unsafe class JavaBoxingTest
{
    private readonly JavaRuntime _runtime = TestJvm.Bootstrap();

    private JNIEnv Env => _runtime.Env;

    [TestMethod]
    public void TryUnbox_Converts_Strings_And_Boxed_Primitives()
    {
        AssertUnboxes("héllo", (_JObject)Env.AsJString("héllo"));
        AssertUnboxes("nul\0 and \U0001F600", (_JObject)Env.AsJString("nul\0 and \U0001F600"));
        AssertUnboxes("", (_JObject)Env.AsJString(""));
        AssertUnboxes(1.5d, Box("java/lang/Double", "(D)Ljava/lang/Double;", new _JValue(1.5d)));
        AssertUnboxes(2.5f, Box("java/lang/Float", "(F)Ljava/lang/Float;", new _JValue(2.5f)));
        AssertUnboxes(42, Box("java/lang/Integer", "(I)Ljava/lang/Integer;", new _JValue(42)));
        AssertUnboxes(42L, Box("java/lang/Long", "(J)Ljava/lang/Long;", new _JValue(42L)));
        AssertUnboxes((short)7, Box("java/lang/Short", "(S)Ljava/lang/Short;", new _JValue((short)7)));
        AssertUnboxes((sbyte)-3, Box("java/lang/Byte", "(B)Ljava/lang/Byte;", new _JValue(unchecked((byte)-3))));
        AssertUnboxes('x', Box("java/lang/Character", "(C)Ljava/lang/Character;", new _JValue((ushort)'x')));
        AssertUnboxes(true, Box("java/lang/Boolean", "(Z)Ljava/lang/Boolean;", new _JValue(_JBoolean.True)));
    }

    [TestMethod]
    public void Box_Round_Trips_Through_TryUnbox()
    {
        object[] values = ["text", true, (sbyte)-3, 'x', (short)7, 42, 42L, 2.5f, 1.5d];
        foreach (var expected in values)
            AssertUnboxes(expected, JavaBoxing.Box(Env, expected));

        Assert.IsTrue(JavaBoxing.Box(Env, null).IsNull);
        Assert.ThrowsExactly<ArgumentException>(() => JavaBoxing.Box(Env, new object()));
    }

    [TestMethod]
    public void TryUnbox_Null_Is_Null()
    {
        Assert.IsTrue(JavaBoxing.TryUnbox(Env, _JObject.Null, out var value));
        Assert.IsNull(value);
    }

    [TestMethod]
    public void TryUnbox_Other_Objects_Returns_False_And_They_Can_Be_Described()
    {
        var builder = Env.NewObject("java/lang/StringBuilder", "(Ljava/lang/String;)V", new _JValue((_JObject)Env.AsJString("sb")));

        Assert.IsFalse(JavaBoxing.TryUnbox(Env, builder, out _));
        Assert.AreEqual("java.lang.StringBuilder", JavaBoxing.GetClassName(Env, builder));
        Assert.AreEqual("sb", JavaBoxing.ToJavaString(Env, builder));
        Assert.AreEqual("null", JavaBoxing.ToJavaString(Env, _JObject.Null));
    }

    [TestMethod]
    public void IsSameObject_Compares_Referents_Not_References()
    {
        var builder = Env.NewObject("java/lang/StringBuilder", "()V");
        var global = Env.NewGlobalRef(builder);
        var other = Env.NewObject("java/lang/StringBuilder", "()V");

        Assert.IsTrue(Env.IsSameObject(builder, global));
        Assert.IsFalse(Env.IsSameObject(builder, other));
        Env.DeleteGlobalRef(global);
    }

    private void AssertUnboxes(object expected, _JObject obj)
    {
        Assert.IsTrue(JavaBoxing.TryUnbox(Env, obj, out var value));
        Assert.AreEqual(expected, value);
        Assert.AreEqual(expected.GetType(), value!.GetType());
    }

    private _JObject Box(string cls, string signature, _JValue value)
    {
        var boxClass = Env.FindClass(cls);
        var valueOf = Env.GetStaticMethodId(boxClass, "valueOf", signature);
        _JValue* args = stackalloc _JValue[] { value };
        return Env.CallStaticObjectMethod(boxClass, valueOf, args);
    }
}
