namespace JNIBinding.Exceptions;

public class JNIClassNotFoundException(string className) : JNIException($"{className} not found");

public class JRuntimeException(string message) : JNIException(message);