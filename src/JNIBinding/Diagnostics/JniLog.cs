using System.Diagnostics;

namespace JNIBinding.Diagnostics;

public enum JniLogLevel
{
    Trace,
    Debug,
    Info,
    Warn,
    Error,
}

/// <summary>
/// Library log output. Replace <see cref="Sink"/> to redirect it into the host's logging; by default it goes to
/// <see cref="System.Diagnostics.Debug"/>, which is only visible with a debugger or trace listener attached.
/// </summary>
public static class JniLog
{
    public static Action<JniLogLevel, string, string> Sink { get; set; } =
        (level, source, message) => System.Diagnostics.Debug.WriteLine($"[{level}][{source}] {message}");

    /// <summary>High-volume binding detail; compiled out of Release builds so it costs nothing there.</summary>
    [Conditional("DEBUG")]
    public static void Trace(string source, string message) => Sink(JniLogLevel.Trace, source, message);

    public static void Debug(string source, string message) => Sink(JniLogLevel.Debug, source, message);

    public static void Info(string source, string message) => Sink(JniLogLevel.Info, source, message);

    public static void Warn(string source, string message) => Sink(JniLogLevel.Warn, source, message);

    public static void Error(string source, string message) => Sink(JniLogLevel.Error, source, message);
}
