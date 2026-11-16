namespace JNIBinding;

/// <summary>
/// Provides a compiler linkage between JNINativeInterface.Delegates, JNINativeInterface and JNIFunctionBridge
/// </summary>
/// <remarks>
/// Used with nameof() this nicely keeps the compiler aware of what is/isn't being used.
/// It's also used by <see cref="JNIFunctionBinder.Bind"/>
/// </remarks>
/// <param name="target"></param>
public class JNIFunctionBindingAttribute(string target) : Attribute
{
    public string Target = target;
}