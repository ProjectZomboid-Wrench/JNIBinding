namespace JNIBinding.Bindings.Native;

public enum JniResult
{
    Success = 0,            /* Success */
    Error = -1,             /* Unknown Error */
    ThreadDetached = -2,    /* Thread detached from VM */
    VersionError = -3,      /* JNI Version Error */
    NotEnoughMemory = -4,   /* Not Enough Memory */
    AlreadyExists = -5,     /* VM already created */
    InvalidArguments = -6   /* Invalid Arguments */
}