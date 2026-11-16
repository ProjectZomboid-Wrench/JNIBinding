using System.Text;

namespace JNIBinding.Bindings.Decorated;

public class JavaClassLoader
{
    public JavaClassLoader()
    {
    }
}

/*
 * Java Name Mangling Rules
 *
 * Primitive Types:
 * V - void
 * Z - boolean
 * C - char
 * B - byte
 * S - short
 * I - int
 * F - float
 * J - long
 * D - double
 *
 * Class Representations:
 * L<class>;
 * ex. Ljava/lang/Object;
 *
 * Method Signatures:
 * public void method() = ()V
 * public void method(String s, int i) = (Ljava/lang/String;I)V
 * public String method(String s, int i, boolean flag) = (Ljava/lang/String;IZ)Ljava/Lang/String;
 *
 * TODO: Would be helpful to turn Expression<Func<string,int,boolean,string>> into a _JName
 */

public struct _JName(string name)
{
    public readonly string Value = name;
}

public class JavaName
{
    public static _JName BuildClassName(string className)
    {
        if (className.Contains("."))
        {
            return new _JName($"L{className.Replace('.', '/')}");
        } else if (className.Contains("/"))
        {
            return new _JName($"L{className}");
        }
        else
        {
            throw new ArgumentException("Invalid java class format", nameof(className));
        }
    }
}