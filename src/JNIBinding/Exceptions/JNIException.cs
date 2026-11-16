using System.Runtime.Serialization;

namespace JNIBinding.Exceptions;

public class JNIException : Exception
{
    public JNIException()
    {
    }

    protected JNIException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public JNIException(string? message) : base(message)
    {
    }

    public JNIException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}