namespace JNIBinding.Bindings.Native;

/// <summary>
/// Used by ReleaseScalarArrayElements
/// </summary>
public enum ScalarArrayReleaseMode
{
    JNI_COMMIT = 1,
    JNI_ABORT = 2,
}