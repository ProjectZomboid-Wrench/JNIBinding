namespace JNIBinding.Bindings.Native.Types;

/*
 * V - void
 * Z - boolean
 * C - char
 * B - byte
 * S - short
 * I - int
 * F - float
 * J - long
 * D - double
 * L - Reference
 */

public static class _JType {
    /// <summary>
    /// Decode a single char primitive java type identifier to a _JTypeInfo
    /// </summary>
    /// <remarks>
    /// Works with the mangled type name such as D, V, Z, etc
    /// </remarks>
    /// <param name="type">Java Type Identifier</param>
    /// <returns><see cref="_JTypeInfo"/></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static _JTypeInfo From(char type)
    {
        return type switch
        {
            'V' => _JTypeInfo.Void,
            'Z' => _JTypeInfo.Boolean,
            'C' => _JTypeInfo.Char,
            'B' => _JTypeInfo.Byte,
            'S' => _JTypeInfo.Short,
            'I' => _JTypeInfo.Int,
            'F' => _JTypeInfo.Float,
            'J' => _JTypeInfo.Long,
            'D' => _JTypeInfo.Double,
            'L' => _JTypeInfo.ClassName,
            '[' => _JTypeInfo.Array,
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
}