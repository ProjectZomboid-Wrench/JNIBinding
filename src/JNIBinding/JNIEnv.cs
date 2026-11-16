using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using JNIBinding.Bindings.Native;
using JNIBinding.Bindings.Native.Types;

namespace JNIBinding;

/// <summary>
/// A very thin wrapper around the JNINativeInterface using Native.Types
/// The first-layer _J* objects do not store much more than the IntPtr to the result.
/// </summary>
/// <remarks>
/// This layer of JNet gives complete control over JNI with a veneer of types, it
/// doesn't do much error checking and expects the API consumer to handle bookkeeping
/// of object details in the calling code.
///
/// These functions do not explicitly check that they aren't returning null pointers, buyer beware.
/// </remarks>
public unsafe class JNIEnv : IDisposable
{
    // TODO: This should probably keep a ref to _JVM
    
    /// <summary>
    /// Pointer to the JNIEnv held by the JVM
    /// </summary>
    public readonly _JNIEnv EnvHandle;
    
    /// <summary>
    /// Pointer to the JNIEnv held by the JVM but with access to the exported functions.
    /// </summary>
    public readonly JNINativeInterface* FuncHandle;
    
    public readonly JNIFunctionBridge Functions;

    /// <summary>
    /// A _JNIEnv is a polite wrapper around an IntPtr, this lets you have
    /// it as an IntPtr
    /// </summary>
    public static implicit operator IntPtr(JNIEnv env) => env.EnvHandle;

    [ThreadStatic] private static JNIEnv? _threadCached;

    /// <summary>
    /// Returns a wrapper for a handle obtained on the calling thread, reusing the previous one when the handle is
    /// unchanged. Prefer this to the constructor, which binds every JNI function and is expensive.
    /// </summary>
    public static JNIEnv ForHandle(_JNIEnv handle)
    {
        var cached = _threadCached;
        if (cached is not null && cached.EnvHandle.Value == handle.Value)
            return cached;
        return _threadCached = new JNIEnv(handle);
    }

    public JNIEnv(_JNIEnv jniEnvHandle)
    {
        EnvHandle = jniEnvHandle;
        FuncHandle = (*(JNINativeInterfacePtr*)jniEnvHandle.ToPointer()).functions;
        
        // Bind all known delegates to their function pointers
        Functions = new JNIFunctionBridge(*FuncHandle);
        JNIFunctionBinder.Bind(Functions, *FuncHandle);
    }

    public int GetVersion()
    {
        var version = Functions.GetVersion(EnvHandle);
        this.SurfaceException();
        return version;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
    
    public bool IsInstanceOf(_JObject obj, _JClass cls) => Functions.IsInstanceOf(EnvHandle, obj, cls) != 0;

    public _JClass GetObjectClass(_JObject obj) => new(Functions.GetObjectClass(EnvHandle, obj));

    public _JClass FindClass(string name)
    {
        var res = Functions.FindClass(EnvHandle, name);
        CheckJavaExceptionAndThrow();
        return new _JClass(res);
    }
    
    public _JObjectArray NewObjectArray(int len, _JClass clazz, _JObject initValue)
    {
        IntPtr res = Functions.NewObjectArray(EnvHandle, len, clazz, initValue);
        CheckJavaExceptionAndThrow();
        return new _JObjectArray(res);
    }

    public _JObject NewObjectA(_JClass clsHnd, _JMethodID methodId, _JValue* args)
    {
        return Functions.NewObjectA(EnvHandle, clsHnd, methodId, args);
    }

    public void SetObjectArrayElement(IntPtr arrayPtr, int index, IntPtr valPtr)
    {
        Functions.SetObjectArrayElement(EnvHandle, arrayPtr, index, valPtr);
        CheckJavaExceptionAndThrow();
    }

    public _JObject GetObjectArrayElement(_JObjectArray jArray, int index)
    {
        IntPtr res = Functions.GetObjectArrayElement(EnvHandle, jArray, index);
        CheckJavaExceptionAndThrow();
        return new _JObject(res);
    }

    public _JMethodID GetMethodId(_JClass clsPtr, string methodName, string methodSig)
    {
        var res = Functions.GetMethodID(EnvHandle, clsPtr, methodName, methodSig);
        CheckJavaExceptionAndThrow();
        return new _JMethodID(res);
    }

    public _JMethodID GetStaticMethodId(_JClass clsPtr, string methodName, string methodSig)
    {
        var res = Functions.GetStaticMethodID(EnvHandle, clsPtr, methodName, methodSig);
        CheckJavaExceptionAndThrow();
        return new _JMethodID(res);
    }

    public void CallVoidMethodA(_JObject instance, _JMethodID methodId, _JValue* args)
    {
        Functions.CallVoidMethod(EnvHandle, instance, methodId, args);
    }
    
    public _JBoolean CallStaticBooleanMethod(_JClass cls, _JMethodID methodId, _JValue* args)
    {
        var res = Functions.CallStaticBooleanMethod(EnvHandle, cls, methodId, args);
        CheckJavaExceptionAndThrow();
        return new _JBoolean(res);
    }

    public _JBoolean CallBooleanMethod(_JObject instance, _JMethodID methodId, params _JValue[] args)
    {
        fixed (_JValue* ptr = args)
        {
            var res = Functions.CallBooleanMethod(EnvHandle, instance, methodId, ptr);
            CheckJavaExceptionAndThrow();
            return new _JBoolean(res);
        }
    }

    public _JBoolean CallBooleanMethod(_JObject instance, _JMethodID methodId, _JValue* args)
    {
        var res = Functions.CallBooleanMethod(EnvHandle, instance, methodId, args);
        CheckJavaExceptionAndThrow();
        return new _JBoolean(res);
    }

    public byte CallStaticByteMethod(_JClass cls, _JMethodID methodId, _JValue* args)
    {
        var res = Functions.CallStaticByteMethod(EnvHandle, cls, methodId, args);
        CheckJavaExceptionAndThrow();
        return res;
    }

    public byte CallByteMethod(_JObject instance, _JMethodID methodId, _JValue* args)
    {
        var res = Functions.CallByteMethod(EnvHandle, instance, methodId, args);
        CheckJavaExceptionAndThrow();
        return res;
    }

    public UInt16 CallStaticCharMethod(_JClass cls, _JMethodID methodId, _JValue* args)
    {
        var res = Functions.CallStaticCharMethod(EnvHandle, cls, methodId, args);
        CheckJavaExceptionAndThrow();
        return res;
    }
    
    public UInt16 CallCharMethod(_JObject instance, _JMethodID methodId, params _JValue[] args)
    {
        fixed (_JValue* ptr = args)
        {
            var res = Functions.CallCharMethod(EnvHandle, instance, methodId, ptr);
            CheckJavaExceptionAndThrow();
            return res;
        }
    }

    public UInt16 CallCharMethod(_JObject instance, _JMethodID methodId, _JValue* args)
    {
        var res = Functions.CallCharMethod(EnvHandle, instance, methodId, args);
        CheckJavaExceptionAndThrow();
        return res;
    }

    public Int16 CallStaticShortMethod(_JClass cls, _JMethodID methodId, _JValue* args)
    {
        var res = Functions.CallStaticShortMethod(EnvHandle, cls, methodId, args);
        CheckJavaExceptionAndThrow();
        return res;
    }

    public Int16 CallShortMethod(_JObject instance, _JMethodID methodId, params _JValue[] args)
    {
        fixed (_JValue* ptr = args)
        {
            var res = Functions.CallShortMethod(EnvHandle, instance, methodId, ptr);
            CheckJavaExceptionAndThrow();
            return res;
        }
    }

    public Int16 CallShortMethod(_JObject instance, _JMethodID methodId, _JValue* args)
    {
        var res = Functions.CallShortMethod(EnvHandle, instance, methodId, args);
        CheckJavaExceptionAndThrow();
        return res;
    }

    public Int32 CallStaticIntMethod(_JClass cls, _JMethodID methodId, _JValue* args)
    {
        var res = Functions.CallStaticIntMethod(EnvHandle, cls, methodId, args);
        CheckJavaExceptionAndThrow();
        return res;
    }

    public Int32 CallIntMethod(_JObject instance, _JMethodID methodId, _JValue* args)
    {
        var res = Functions.CallIntMethod(EnvHandle, instance, methodId, args);
        CheckJavaExceptionAndThrow();
        return res;
    }
    
    public Int32 CallIntMethod(_JObject instance, _JMethodID methodId, params _JValue[] args)
    {
        fixed (_JValue* ptr = args)
        {
            var res = Functions.CallIntMethod(EnvHandle, instance, methodId, ptr);
            CheckJavaExceptionAndThrow();
            return res;
        }
    }

    public Int64 CallStaticLongMethod(_JClass cls, _JMethodID methodId, _JValue* args)
    {
        var res = Functions.CallStaticLongMethod(EnvHandle, cls, methodId, args);
        CheckJavaExceptionAndThrow();
        return res;
    }

    public Int64 CallLongMethod(_JObject instance, _JMethodID methodId, _JValue* args)
    {
        var res = Functions.CallLongMethod(EnvHandle, instance, methodId, args);
        CheckJavaExceptionAndThrow();
        return res;
    }

    public Single CallStaticFloatMethod(_JClass cls, _JMethodID methodId, _JValue* args)
    {
        var res = Functions.CallStaticFloatMethod(EnvHandle, cls, methodId, args);
        CheckJavaExceptionAndThrow();
        return res;
    }

    public Single CallFloatMethod(_JObject instance, _JMethodID methodId, _JValue* args)
    {
        var res = Functions.CallFloatMethod(EnvHandle, instance, methodId, args);
        CheckJavaExceptionAndThrow();
        return res;
    }

    public Double CallStaticDoubleMethod(_JClass cls, _JMethodID methodId, _JValue* args)
    {
        var res = Functions.CallStaticDoubleMethod(EnvHandle, cls, methodId, args);
        CheckJavaExceptionAndThrow();
        return res;
    }

    public Double CallDoubleMethod(_JObject instance, _JMethodID methodId, _JValue* args)
    {
        var res = Functions.CallDoubleMethod(EnvHandle, instance, methodId, args);
        CheckJavaExceptionAndThrow();
        return res;
    }

    public _JObject CallStaticObjectMethod(_JClass cls, _JMethodID methodId, _JValue* args)
    {
        var res = Functions.CallStaticObjectMethod(EnvHandle, cls, methodId, args);
        CheckJavaExceptionAndThrow();
        return new _JObject(res);
    }

    public _JObject CallObjectMethod(_JObject instance, _JMethodID methodId, _JValue* args)
    {
        var res = Functions.CallObjectMethod(EnvHandle, instance, methodId, args);
        CheckJavaExceptionAndThrow();
        return new _JObject(res);
    }

    public void CallStaticVoidMethod(_JClass cls, _JMethodID methodId, _JValue* args)
    {
        Functions.CallStaticVoidMethod(EnvHandle, cls, methodId, args);
        CheckJavaExceptionAndThrow();
    }

    public void CallVoidMethod(_JObject instance, _JMethodID methodId, _JValue* args)
    {
        Functions.CallVoidMethod(EnvHandle, instance, methodId, args);
        CheckJavaExceptionAndThrow();
    }
    
    public IntPtr RegisterNatives(_JClass cls, JNINativeMethod* methods, int nMethods)
    {
        return Functions.RegisterNatives(EnvHandle, cls, methods, nMethods);
    }

    public IntPtr UnregisterNatives(_JClass cls)
    {
        return Functions.UnregisterNatives(EnvHandle, cls);
    }

    public _JFieldID GetFieldID(_JClass clsHnd, string name, string signature)
    {
        return Functions.GetFieldID(EnvHandle, clsHnd, name, signature);
    }

    public _JFieldID GetStaticFieldID(_JClass classHnd, string name, string signature)
    {
        return Functions.GetStaticFieldID(EnvHandle, classHnd, name, signature);
    }

    public int ThrowNew(_JClass classHnd, byte* msg)
    {
        return Functions.ThrowNew(EnvHandle, classHnd, new IntPtr(msg));
    }

    public _JByteArray NewByteArray(int size)
    {
        return Functions.NewByteArray(EnvHandle, size);
    }

    public _JString NewStringUTF(byte* utfStr)
    {
        return Functions.NewStringUTF(EnvHandle, (IntPtr)utfStr);
    }

    public void SetByteArrayRegion(_JByteArray arrayHnd, int start, int len, byte* buffer)
    {
        Functions.SetByteArrayRegion(EnvHandle, arrayHnd, start, len, buffer);
    }

    public void PushLocalFrame(int capacity) => Functions.PushLocalFrame(EnvHandle, capacity);

    public _JObject PopLocalFrame(_JObject result) => Functions.PopLocalFrame(EnvHandle, result);

    public _JObject CallObjectMethodA(_JObject jObj, _JMethodID methodBytes, _JValue* args)
    {
        return Functions.CallObjectMethodA(EnvHandle, jObj, methodBytes, args);
    }

    public int GetArrayLength(_JArray arrayHnd)
    {
        return Functions.GetArrayLength(EnvHandle, arrayHnd);
    }

    public void GetByteArrayRegion(_JByteArray arrayHnd, int start, int len, byte* buffer)
    {
        Functions.GetByteArrayRegion(EnvHandle, arrayHnd, start, len, buffer);
    }
    
    public _JBoolean GetStaticBooleanField(_JClass clsHnd, _JFieldID jFieldId)
    {
        return Functions.GetStaticBooleanField(EnvHandle, clsHnd, jFieldId);
    }

    public byte GetStaticByteField(_JClass clsHnd, _JFieldID jFieldId)
    {
        return Functions.GetStaticByteField(EnvHandle, clsHnd, jFieldId);
    }

    public _JObject GetStaticObjectField(_JClass clsHnd, _JFieldID jFieldId)
    {
        return Functions.GetStaticObjectField(EnvHandle, clsHnd, jFieldId);
    }

    public UInt16 GetStaticCharField(_JClass clsHnd, _JFieldID jFieldId)
    {
        return Functions.GetStaticCharField(EnvHandle, clsHnd, jFieldId);
    }

    public short GetStaticShortField(_JClass clsHnd, _JFieldID jFieldId)
    {
        return Functions.GetStaticShortField(EnvHandle, clsHnd, jFieldId);
    }

    public int GetStaticIntField(_JClass clsHnd, _JFieldID jFieldId)
    {
        return Functions.GetStaticIntField(EnvHandle, clsHnd, jFieldId);
    }

    public long GetStaticLongField(_JClass clsHnd, _JFieldID jFieldId)
    {
        return Functions.GetStaticLongField(EnvHandle, clsHnd, jFieldId);
    }

    public float GetStaticFloatField(_JClass clsHnd, _JFieldID jFieldId)
    {
        return Functions.GetStaticFloatField(EnvHandle, clsHnd, jFieldId);
    }

    public double GetStaticDoubleField(_JClass clsHnd, _JFieldID jFieldId) =>
        Functions.GetStaticDoubleField(EnvHandle, clsHnd, jFieldId);

    public _JBoolean GetBooleanField(_JObject instance, _JFieldID jFieldId) =>
        Functions.GetBooleanField(EnvHandle, instance, jFieldId);

    public UInt16 GetCharField(_JObject instance, _JFieldID jFieldId) =>
        Functions.GetCharField(EnvHandle, instance, jFieldId);

    public short GetShortField(_JObject instance, _JFieldID jFieldId) =>
        Functions.GetShortField(EnvHandle, instance, jFieldId);

    public int GetIntField(_JObject instance, _JFieldID jFieldId) =>
        Functions.GetIntField(EnvHandle, instance, jFieldId);

    public long GetLongField(_JObject instance, _JFieldID jFieldId) =>
        Functions.GetLongField(EnvHandle, instance, jFieldId);

    public float GetFloatField(_JObject instance, _JFieldID jFieldId) =>
        Functions.GetFloatField(EnvHandle, instance, jFieldId);

    public double GetDoubleField(_JObject instance, _JFieldID jFieldId) =>
        Functions.GetDoubleField(EnvHandle, instance, jFieldId);

    public _JObject GetObjectField(_JObject instance, _JFieldID jFieldId) =>
        Functions.GetObjectField(EnvHandle, instance, jFieldId);

    public _JObject NewGlobalRef(_JObject objHnd) => Functions.NewGlobalRef(EnvHandle, objHnd);
    
    public void DeleteLocalRef(_JObject lRef) => Functions.DeleteLocalRef(EnvHandle, lRef);

    public void DeleteGlobalRef(_JObject gRef) => Functions.DeleteGlobalRef(EnvHandle, gRef);
    
    public _JThrowable ExceptionOccurred()
    {
        return Functions.ExceptionOccurred(EnvHandle);
    }

    public void ExceptionClear()
    {
        Functions.ExceptionClear(EnvHandle);
    }

    public void ExceptionDescribe()
    {
        Functions.ExceptionDescribe(EnvHandle);
    }

    /// <summary>Clears any pending Java exception and rethrows it as a <see cref="JavaThrowable"/>.</summary>
    public bool CheckJavaExceptionAndThrow()
    {
        if (Functions.ExceptionCheck(EnvHandle) == 0)
            return false;
        this.SurfaceException();
        return true;
    }

    /// <summary>
    /// Wrap an <see cref="IntPtr"/> reference to a <seealso cref="JNINativeInterface"/>
    /// function with a <seealso cref="JNINativeInterface_"/> delegate making it callable.
    /// </summary>
    /// <param name="_ptr"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static T Wrap<T>(nint _ptr) where T: Delegate
    {
        Debug.WriteLine($"[TRACE][JEnv] ResolveFunctionPointer: {typeof(T)}(0x{_ptr:x4})");
        T res = null!;
        JVM.GetDelegateForFunctionPointer(_ptr, ref res);
        if (res == null)
            throw new ArgumentException($"Unable to wrap {typeof(T)} around (0x{_ptr:x4})");
        return res;
    }

    public _JClass FetchObjectClass()
    {
        return FindClass("java/lang/Object");
    }

    public IntPtr GetDirectBufferAddress(_JObject valueRef)
    {
        return Functions.GetDirectBufferAddress(EnvHandle, valueRef);
    }

    public Int32 Throw(_JThrowable throwable)
    {
        return Functions.Throw(EnvHandle, throwable);
    }

    public override string ToString()
    {
        return $"{nameof(JNIEnv)} ({EnvHandle})";
    }
}