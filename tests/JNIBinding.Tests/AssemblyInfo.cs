using Microsoft.VisualStudio.TestTools.UnitTesting;

// Tests share the process's single JVM, and JNIEnv handles are thread-bound.
[assembly: DoNotParallelize]
