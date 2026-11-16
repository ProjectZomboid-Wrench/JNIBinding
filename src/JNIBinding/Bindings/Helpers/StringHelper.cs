using System.Diagnostics;
using System.Runtime.InteropServices;

namespace JNIBinding;

/// <summary>
/// Helper methods for getting unmanaged addresses to .net strings
/// </summary>
public static class StringHelper
{
    private static IntPtr TrackString(string s)
    {
        // TODO: Track any unmanaged string pointers and free them when no longer wanted
        var ptr = Marshal.StringToHGlobalAnsi(s);
        Debug.Write($"{nameof(TrackString)}:: Tracking unmanaged string('{s}') @ {ptr:X16}");
        
        return ptr;
    }

    /// <summary>
    /// Copy <paramref name="s"/> to global memory as an ANSI string and return the location
    /// of the start of the memory location
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static nint GetUnmanagedAddress(string s) => TrackString(s);
    
    /// <summary>
    /// Copy <paramref name="s"/> to a global memory as an ANSI string and return a .net pointer
    /// to the start of the memory location
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static IntPtr AsPointerSafe(string s) => TrackString(s);

    /// <summary>
    /// Copy <paramref name="s"/> to global memory as an ANSI string and return a pointer
    /// to the start of the memory location as a void*
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static unsafe void* AsRef(string s) => TrackString(s).ToPointer();
}