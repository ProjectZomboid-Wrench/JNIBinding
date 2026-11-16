using System;
using System.IO;
using JNIBinding.Bindings;

namespace JNIBinding.Tests;

internal static class TestJvm
{
    public static readonly IVMRef Library = new JvmLibrary();

    // Options only apply to whichever test creates the process's JVM, so every test must pass the same ones.
    public static JavaRuntime Bootstrap() =>
        JavaRuntime.Bootstrap(Library, $"-Djava.class.path={Path.Combine(AppContext.BaseDirectory, "classes")}");
}
