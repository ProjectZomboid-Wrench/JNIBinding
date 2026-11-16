using System.Runtime.InteropServices;
using JNIBinding.Bindings.Native.Types;

// ReSharper disable InconsistentNaming

namespace JNIBinding.Bindings.Native;

/// <summary>
/// Contains all the delegates for JNINativeInterface. See <see cref="JNINativeInterface"/> for the raw IntPtr struct
/// </summary>
public unsafe struct JNINativeInterface_
{
    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.AllocObject))]
    public delegate IntPtr AllocObject(IntPtr EnvironmentHandle, IntPtr jniClass);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.CallBooleanMethod))]
    public delegate byte CallBooleanMethod(
        IntPtr EnvironmentHandle, IntPtr obj, IntPtr jMethodID, _JValue* args);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.CallByteMethod))]
    public delegate byte CallByteMethod(
        IntPtr EnvironmentHandle, IntPtr obj, IntPtr jMethodId, _JValue* args);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.CallCharMethod))]
    public delegate ushort CallCharMethod(
        IntPtr EnvironmentHandle, IntPtr obj, IntPtr jMethodId, _JValue* args);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.CallDoubleMethod))]
    public delegate double CallDoubleMethod(
        IntPtr EnvironmentHandle, IntPtr obj, IntPtr jMethodId, _JValue* args);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.CallFloatMethod))]
    public delegate float CallFloatMethod(
        IntPtr EnvironmentHandle, IntPtr obj, IntPtr jMethodId, _JValue* args);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.CallIntMethod))]
    public delegate int CallIntMethod(
        IntPtr EnvironmentHandle, IntPtr obj, IntPtr jMethodID, _JValue* args);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.CallLongMethod))]
    public delegate long CallLongMethod(
        IntPtr EnvironmentHandle, IntPtr obj, IntPtr jMethodId, _JValue* args);

    [UnmanagedFunctionPointer(CallingConvention.StdCall),
     JNIFunctionBinding(nameof(JNINativeInterface.CallObjectMethod))]
    public delegate IntPtr CallObjectMethod(
        IntPtr EnvironmentHandle, IntPtr obj, IntPtr jMethodId, _JValue* args);    
    
    [UnmanagedFunctionPointer(CallingConvention.StdCall),
     JNIFunctionBinding(nameof(JNINativeInterface.CallObjectMethodA))]
    public delegate IntPtr CallObjectMethodA(
     IntPtr EnvironmentHandle, IntPtr obj, IntPtr jMethodId, _JValue* pArgs);
    
    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.CallShortMethod))]
    public delegate short CallShortMethod(
        IntPtr EnvironmentHandle, IntPtr obj, IntPtr jMethodId, _JValue* args);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.CallVoidMethod))]
    public delegate void CallVoidMethod(
        IntPtr EnvironmentHandle, IntPtr obj, IntPtr jMethodId, _JValue* args);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.CallNonvirtualBooleanMethod))]
    public delegate byte CallNonvirtualBooleanMethod(IntPtr EnvironmentHandle, IntPtr obj, IntPtr jniClass, IntPtr jMethodId,
        _JValue* args);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.CallNonvirtualByteMethod))]
    public delegate byte CallNonvirtualByteMethod(IntPtr EnvironmentHandle, IntPtr obj, IntPtr jniClass,
        IntPtr jMethodId, _JValue* args);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.CallNonvirtualCharMethod))]
    public delegate ushort CallNonvirtualCharMethod(IntPtr EnvironmentHandle, IntPtr obj, IntPtr jniClass,
        IntPtr jMethodId, _JValue* args);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.CallNonvirtualDoubleMethod))]
    public delegate double CallNonvirtualDoubleMethod(IntPtr EnvironmentHandle, IntPtr obj, IntPtr jniClass,
        IntPtr jMethodId, _JValue* args);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.CallNonvirtualFloatMethod))]
    public delegate float CallNonvirtualFloatMethod(IntPtr EnvironmentHandle, IntPtr obj, IntPtr jniClass,
        IntPtr jMethodId, _JValue* args);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.CallNonvirtualIntMethod))]
    public delegate int CallNonvirtualIntMethod(IntPtr EnvironmentHandle, IntPtr obj, IntPtr jniClass, IntPtr jMethodId,
        _JValue* args);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.CallNonvirtualLongMethod))]
    public delegate long CallNonvirtualLongMethod(IntPtr EnvironmentHandle, IntPtr obj, IntPtr jniClass,
        IntPtr jMethodId, _JValue* args);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.CallNonvirtualObjectMethod))]
    public delegate IntPtr CallNonvirtualObjectMethod(IntPtr EnvironmentHandle, IntPtr obj, IntPtr jniClass,
        IntPtr jMethodId, _JValue* args);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.CallNonvirtualShortMethod))]
    public delegate short CallNonvirtualShortMethod(IntPtr EnvironmentHandle, IntPtr obj, IntPtr jniClass,
        IntPtr jMethodId, _JValue* args);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.CallNonvirtualVoidMethod))]
    public delegate void CallNonvirtualVoidMethod(IntPtr EnvironmentHandle, IntPtr obj, IntPtr jniClass,
        IntPtr jMethodId, _JValue* args);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.CallStaticBooleanMethod))]
    public delegate JBoolean CallStaticBooleanMethod(IntPtr EnvironmentHandle, IntPtr jniClass, IntPtr jMethodId,
     _JValue* args);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.CallStaticByteMethod))]
    public delegate byte CallStaticByteMethod(IntPtr EnvironmentHandle, IntPtr jniClass, IntPtr jMethodId,
        _JValue* args);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.CallStaticCharMethod))]
    public delegate ushort CallStaticCharMethod(IntPtr EnvironmentHandle, IntPtr jniClass, IntPtr jMethodId,
        _JValue* args);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.CallStaticDoubleMethod))]
    public delegate double CallStaticDoubleMethod(IntPtr EnvironmentHandle, IntPtr jniClass, IntPtr jMethodId,
        _JValue* args);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.CallStaticFloatMethod))]
    public delegate float CallStaticFloatMethod(IntPtr EnvironmentHandle, IntPtr jniClass, IntPtr jMethodId,
        _JValue* args);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.CallStaticIntMethod))]
    public delegate int CallStaticIntMethod(IntPtr EnvironmentHandle, IntPtr obj, IntPtr jMethodID,
        _JValue* args);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.CallStaticLongMethod))]
    public delegate long CallStaticLongMethod(IntPtr EnvironmentHandle, IntPtr jniClass, IntPtr jMethodId,
        _JValue* args);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.CallStaticObjectMethod))]
    public delegate IntPtr CallStaticObjectMethod(IntPtr EnvironmentHandle, IntPtr jniClass, IntPtr jMethodId,
        _JValue* args);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.CallStaticShortMethod))]
    public delegate short CallStaticShortMethod(IntPtr EnvironmentHandle, IntPtr jniClass, IntPtr jMethodId,
        _JValue* args);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.CallStaticVoidMethod))]
    public delegate void CallStaticVoidMethod(IntPtr EnvironmentHandle, IntPtr jniClass, IntPtr jMethodID,
        _JValue* args);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.DefineClass))]
    public delegate IntPtr DefineClass(IntPtr EnvironmentHandle, IntPtr name, IntPtr loader, IntPtr buf, int len);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.DeleteGlobalRef))]
    public delegate void DeleteGlobalRef(IntPtr EnvironmentHandle, IntPtr gref);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.DeleteLocalRef))]
    public delegate void DeleteLocalRef(IntPtr EnvironmentHandle, IntPtr lref);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.DeleteWeakGlobalRef))]
    public delegate void DeleteWeakGlobalRef(IntPtr EnvironmentHandle, IntPtr wref);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.EnsureLocalCapacity))]
    public delegate int EnsureLocalCapacity(IntPtr EnvironmentHandle, int capacity);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.ExceptionCheck))]
    public delegate byte ExceptionCheck(IntPtr EnvironmentHandle);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.ExceptionClear))]
    public delegate void ExceptionClear(IntPtr EnvironmentHandle);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.ExceptionDescribe))]
    public delegate void ExceptionDescribe(IntPtr EnvironmentHandle);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.ExceptionOccurred))]
    public delegate IntPtr ExceptionOccurred(IntPtr EnvironmentHandle);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.FatalError))]
    public delegate void FatalError(IntPtr EnvironmentHandle, IntPtr msg);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.FindClass))]
    public delegate IntPtr FindClass(IntPtr EnvironmentHandle, [MarshalAs(UnmanagedType.LPStr)] string name);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.GetSuperclass))]
    public delegate IntPtr GetSuperclass(IntPtr EnvironmentHandle, IntPtr subclassHandle);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.IsAssignableFrom))]
    public delegate byte IsAssignableFrom(IntPtr EnvironmentHandle, IntPtr subclassHandle, IntPtr superclassHandle);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.FromReflectedField))]
    public delegate IntPtr FromReflectedField(IntPtr EnvironmentHandle, IntPtr field);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.FromReflectedMethod))]
    public delegate IntPtr FromReflectedMethod(IntPtr EnvironmentHandle, IntPtr method);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.GetArrayLength))]
    public delegate int GetArrayLength(IntPtr EnvironmentHandle, IntPtr array);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.GetBooleanArrayElements))]
    public delegate byte* GetBooleanArrayElements(IntPtr EnvironmentHandle, IntPtr array, byte* isCopy);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.GetBooleanArrayRegion))]
    public delegate void GetBooleanArrayRegion(IntPtr EnvironmentHandle, IntPtr array, int start, int len, byte* buf);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.GetBooleanField))]
    public delegate JBoolean GetBooleanField(IntPtr EnvironmentHandle, IntPtr obj, IntPtr jFieldId);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.GetByteArrayElements))]
    public delegate byte* GetByteArrayElements(IntPtr EnvironmentHandle, IntPtr array, byte* isCopy);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.GetByteArrayRegion))]
    public delegate void GetByteArrayRegion(IntPtr EnvironmentHandle, IntPtr array, int start, int len, byte* buf);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.GetByteField))]
    public delegate byte GetByteField(IntPtr EnvironmentHandle, IntPtr obj, IntPtr jFieldId);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.GetCharArrayElements))]
    public delegate ushort* GetCharArrayElements(IntPtr EnvironmentHandle, IntPtr array, byte* isCopy);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.GetCharArrayRegion))]
    public delegate void GetCharArrayRegion(IntPtr EnvironmentHandle, IntPtr array, int start, int len, char* buf);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.GetCharField))]
    public delegate ushort GetCharField(IntPtr EnvironmentHandle, IntPtr obj, IntPtr jFieldId);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.GetDirectBufferAddress))]
    public delegate IntPtr GetDirectBufferAddress(IntPtr EnvironmentHandle, IntPtr buf);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.GetDirectBufferCapacity))]
    public delegate long GetDirectBufferCapacity(IntPtr EnvironmentHandle, IntPtr buf);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.GetDoubleArrayElements))]
    public delegate double* GetDoubleArrayElements(IntPtr EnvironmentHandle, IntPtr array, byte* isCopy);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.GetDoubleArrayRegion))]
    public delegate void GetDoubleArrayRegion(IntPtr EnvironmentHandle, IntPtr array, int start, int len, double* buf);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.GetDoubleField))]
    public delegate double GetDoubleField(IntPtr EnvironmentHandle, IntPtr obj, IntPtr jFieldId);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.GetFieldID))]
    public delegate IntPtr GetFieldID(IntPtr EnvironmentHandle, IntPtr jniClass,
        [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string sig);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.GetFloatArrayElements))]
    public delegate float* GetFloatArrayElements(IntPtr EnvironmentHandle, IntPtr array, byte* isCopy);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.GetFloatArrayRegion))]
    public delegate void GetFloatArrayRegion(IntPtr EnvironmentHandle, IntPtr array, int start, int len, float* buf);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.GetFloatField))]
    public delegate float GetFloatField(IntPtr EnvironmentHandle, IntPtr obj, IntPtr jFieldId);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.GetIntArrayElements))]
    public delegate int* GetIntArrayElements(IntPtr EnvironmentHandle, IntPtr array, byte* isCopy);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.GetIntArrayRegion))]
    public delegate void GetIntArrayRegion(IntPtr EnvironmentHandle, IntPtr array, int start, int len, int* buf);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.GetIntField))]
    public delegate int GetIntField(IntPtr EnvironmentHandle, IntPtr obj, IntPtr jFieldId);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.GetJavaVM))]
    public delegate int GetJavaVM(IntPtr EnvironmentHandle, out IntPtr vm);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.GetLongArrayElements))]
    public delegate long* GetLongArrayElements(IntPtr EnvironmentHandle, IntPtr array, byte* isCopy);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.GetLongArrayRegion))]
    public delegate void GetLongArrayRegion(IntPtr EnvironmentHandle, IntPtr array, int start, int len, long* buf);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.GetLongField))]
    public delegate long GetLongField(IntPtr EnvironmentHandle, IntPtr obj, IntPtr jFieldId);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.GetMethodID))]
    public delegate IntPtr GetMethodID(IntPtr EnvironmentHandle, IntPtr jniClass,
        [MarshalAs(UnmanagedType.LPStr)] string name,
        [MarshalAs(UnmanagedType.LPStr)] string sig);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.GetObjectArrayElement))]
    public delegate IntPtr GetObjectArrayElement(IntPtr EnvironmentHandle, IntPtr array, int index);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.GetObjectClass))]
    public delegate IntPtr GetObjectClass(IntPtr EnvironmentHandle, IntPtr obj);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.GetObjectField))]
    public delegate IntPtr GetObjectField(IntPtr EnvironmentHandle, IntPtr obj, IntPtr jFieldId);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.GetPrimitiveArrayCritical))]
    public delegate void* GetPrimitiveArrayCritical(IntPtr EnvironmentHandle, IntPtr array, byte* isCopy);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.GetShortArrayElements))]
    public delegate short* GetShortArrayElements(IntPtr EnvironmentHandle, IntPtr array, byte* isCopy);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.GetShortArrayRegion))]
    public delegate void GetShortArrayRegion(IntPtr EnvironmentHandle, IntPtr array, int start, int len, short* buf);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.GetShortField))]
    public delegate short GetShortField(IntPtr EnvironmentHandle, IntPtr obj, IntPtr jFieldId);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.GetStaticBooleanField))]
    public delegate JBoolean GetStaticBooleanField(IntPtr EnvironmentHandle, IntPtr jniClass, IntPtr jFieldId);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.GetStaticByteField))]
    public delegate byte GetStaticByteField(IntPtr EnvironmentHandle, IntPtr jniClass, IntPtr jFieldId);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.GetStaticCharField))]
    public delegate ushort GetStaticCharField(IntPtr EnvironmentHandle, IntPtr jniClass, IntPtr jFieldId);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.GetStaticDoubleField))]
    public delegate double GetStaticDoubleField(IntPtr EnvironmentHandle, IntPtr jniClass, IntPtr jFieldId);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.GetStaticFieldID))]
    public delegate IntPtr GetStaticFieldID(IntPtr EnvironmentHandle, IntPtr jniClass,
        [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string sig);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.GetStaticFloatField))]
    public delegate float GetStaticFloatField(IntPtr EnvironmentHandle, IntPtr jniClass, IntPtr jFieldId);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.GetStaticIntField))]
    public delegate int GetStaticIntField(IntPtr EnvironmentHandle, IntPtr jniClass, IntPtr jFieldId);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.GetStaticLongField))]
    public delegate long GetStaticLongField(IntPtr EnvironmentHandle, IntPtr jniClass, IntPtr jFieldId);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.GetStaticMethodID))]
    public delegate IntPtr GetStaticMethodID(IntPtr EnvironmentHandle, IntPtr jniClass,
        [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string sig);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.GetStaticObjectField))]
    public delegate IntPtr GetStaticObjectField(IntPtr EnvironmentHandle, IntPtr jniClass, IntPtr jFieldId);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.GetStaticShortField))]
    public delegate short GetStaticShortField(IntPtr EnvironmentHandle, IntPtr jniClass, IntPtr jFieldId);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.GetStringChars))]
    public delegate IntPtr GetStringChars(IntPtr EnvironmentHandle, IntPtr str, byte* isCopy);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.GetStringCritical))]
    public delegate IntPtr GetStringCritical(IntPtr EnvironmentHandle, IntPtr str, byte* isCopy);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.GetStringLength))]
    public delegate int GetStringLength(IntPtr EnvironmentHandle, IntPtr str);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.GetStringRegion))]
    public delegate void GetStringRegion(IntPtr EnvironmentHandle, IntPtr str, int start, int len, char* buf);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.GetStringUTFChars))]
    public delegate IntPtr GetStringUTFChars(IntPtr EnvironmentHandle, IntPtr str, IntPtr isCopy);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.GetStringUTFLength))]
    public delegate int GetStringUTFLength(IntPtr EnvironmentHandle, IntPtr str);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.GetStringUTFRegion))]
    public delegate void GetStringUTFRegion(IntPtr EnvironmentHandle, IntPtr str, int start, int len, char* buf);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.GetVersion))]
    public delegate int GetVersion(IntPtr EnvironmentHandle);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.IsSameObject))]
    public delegate byte IsSameObject(IntPtr EnvironmentHandle, IntPtr o1, IntPtr o2);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.IsInstanceOf))]
    public delegate byte IsInstanceOf(IntPtr EnvironmentHandle, IntPtr obj, IntPtr jniClass);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.MonitorEnter))]
    public delegate int MonitorEnter(IntPtr EnvironmentHandle, IntPtr obj);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.MonitorExit))]
    public delegate int MonitorExit(IntPtr EnvironmentHandle, IntPtr obj);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.NewBooleanArray))]
    public delegate IntPtr NewBooleanArray(IntPtr EnvironmentHandle, int len);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.NewByteArray))]
    public delegate IntPtr NewByteArray(IntPtr EnvironmentHandle, int len);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.NewCharArray))]
    public delegate IntPtr NewCharArray(IntPtr EnvironmentHandle, int len);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.NewDirectByteBuffer))]
    public delegate IntPtr NewDirectByteBuffer(IntPtr EnvironmentHandle, IntPtr address, long capacity);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.NewDoubleArray))]
    public delegate IntPtr NewDoubleArray(IntPtr EnvironmentHandle, int len);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.NewFloatArray))]
    public delegate IntPtr NewFloatArray(IntPtr EnvironmentHandle, int len);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.NewGlobalRef))]
    public delegate IntPtr NewGlobalRef(IntPtr EnvironmentHandle, IntPtr lobj);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.NewIntArray))]
    public delegate IntPtr NewIntArray(IntPtr EnvironmentHandle, int len);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.NewLocalRef))]
    public delegate IntPtr NewLocalRef(IntPtr EnvironmentHandle, IntPtr reference);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.NewLongArray))]
    public delegate IntPtr NewLongArray(IntPtr EnvironmentHandle, int len);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.NewObject))]
    public delegate IntPtr NewObject(IntPtr EnvironmentHandle, IntPtr jniClass, IntPtr jMethodId, _JValue* args);
    
    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.NewObjectA))]
    public delegate IntPtr NewObjectA(IntPtr EnvironmentHandle, IntPtr jniClass, IntPtr jMethodId, _JValue* args);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.NewObjectArray))]
    public delegate IntPtr NewObjectArray(IntPtr EnvironmentHandle, int len, IntPtr jniClass, IntPtr init);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.NewShortArray))]
    public delegate IntPtr NewShortArray(IntPtr EnvironmentHandle, int len);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.NewString))]
    public delegate IntPtr NewString(IntPtr EnvironmentHandle, [MarshalAs(UnmanagedType.LPWStr)] string unicode,
        int len);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.NewStringUTF))]
    public delegate IntPtr NewStringUTF(IntPtr EnvironmentHandle, IntPtr utf);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.NewWeakGlobalRef))]
    public delegate IntPtr NewWeakGlobalRef(IntPtr EnvironmentHandle, IntPtr obj);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.PopLocalFrame))]
    public delegate IntPtr PopLocalFrame(IntPtr EnvironmentHandle, IntPtr result);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.PushLocalFrame))]
    public delegate int PushLocalFrame(IntPtr EnvironmentHandle, int capacity);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.RegisterNatives))]
    public delegate int RegisterNatives(IntPtr EnvironmentHandle, IntPtr jniClass, JNINativeMethod* methods,
        int nMethods);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.UnregisterNatives))]
    public delegate int UnregisterNatives(IntPtr EnvironmentHandle, IntPtr jniClass);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.ReleaseBooleanArrayElements))]
    public delegate void ReleaseBooleanArrayElements(IntPtr EnvironmentHandle, IntPtr array, byte* elems, int mode
    );

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.ReleaseByteArrayElements))]
    public delegate void ReleaseByteArrayElements(IntPtr EnvironmentHandle, IntPtr array, byte* elems, int mode);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.ReleaseCharArrayElements))]
    public delegate void ReleaseCharArrayElements(IntPtr EnvironmentHandle, IntPtr array, ushort* elems, int mode);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.ReleaseDoubleArrayElements))]
    public delegate void ReleaseDoubleArrayElements(IntPtr EnvironmentHandle, IntPtr array, double* elems, int mode);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.ReleaseFloatArrayElements))]
    public delegate void ReleaseFloatArrayElements(IntPtr EnvironmentHandle, IntPtr array, float* elems, int mode);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.ReleaseIntArrayElements))]
    public delegate void ReleaseIntArrayElements(IntPtr EnvironmentHandle, IntPtr array, int* elems, int mode);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.ReleaseLongArrayElements))]
    public delegate void ReleaseLongArrayElements(IntPtr EnvironmentHandle, IntPtr array, long* elems, int mode);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.ReleasePrimitiveArrayCritical))]
    public delegate void ReleasePrimitiveArrayCritical(IntPtr EnvironmentHandle, IntPtr array, void* carray, int mode);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.ReleaseShortArrayElements))]
    public delegate void ReleaseShortArrayElements(IntPtr EnvironmentHandle, IntPtr array, short* elems, int mode);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.ReleaseStringChars))]
    public delegate void ReleaseStringChars(IntPtr EnvironmentHandle, IntPtr str, IntPtr chars);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.ReleaseStringCritical))]
    public delegate void ReleaseStringCritical(IntPtr EnvironmentHandle, IntPtr str, IntPtr cstring);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.ReleaseStringUTFChars))]
    public delegate void ReleaseStringUTFChars(IntPtr EnvironmentHandle, IntPtr str, IntPtr chars);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.SetBooleanArrayRegion))]
    public delegate void SetBooleanArrayRegion(IntPtr EnvironmentHandle, IntPtr array, int start, int len, byte* buf);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.SetBooleanField))]
    public delegate void SetBooleanField(IntPtr EnvironmentHandle, IntPtr obj, IntPtr jFieldId, byte val);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.SetByteArrayRegion))]
    public delegate void SetByteArrayRegion(IntPtr EnvironmentHandle, IntPtr array, int start, int len, byte* buf);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.SetByteField))]
    public delegate void SetByteField(IntPtr EnvironmentHandle, IntPtr obj, IntPtr jFieldId, byte val);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.SetCharArrayRegion))]
    public delegate void SetCharArrayRegion(IntPtr EnvironmentHandle, IntPtr array, int start, int len, char* buf);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.SetCharField))]
    public delegate void SetCharField(IntPtr EnvironmentHandle, IntPtr obj, IntPtr jFieldId, ushort val);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.SetDoubleArrayRegion))]
    public delegate void SetDoubleArrayRegion(IntPtr EnvironmentHandle, IntPtr array, int start, int len, double* buf);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.SetDoubleField))]
    public delegate void SetDoubleField(IntPtr EnvironmentHandle, IntPtr obj, IntPtr jFieldId, double val);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.SetFloatArrayRegion))]
    public delegate void SetFloatArrayRegion(IntPtr EnvironmentHandle, IntPtr array, int start, int len, float* buf);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.SetFloatField))]
    public delegate void SetFloatField(IntPtr EnvironmentHandle, IntPtr obj, IntPtr jFieldId, float val);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.SetIntArrayRegion))]
    public delegate void SetIntArrayRegion(IntPtr EnvironmentHandle, IntPtr array, int start, int len, int* buf);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.SetIntField))]
    public delegate void SetIntField(IntPtr EnvironmentHandle, IntPtr obj, IntPtr jFieldId, int val);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.SetLongArrayRegion))]
    public delegate void SetLongArrayRegion(IntPtr EnvironmentHandle, IntPtr array, int start, int len, long* buf);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.SetLongField))]
    public delegate void SetLongField(IntPtr EnvironmentHandle, IntPtr obj, IntPtr jFieldId, long val);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.SetObjectArrayElement))]
    public delegate void SetObjectArrayElement(IntPtr EnvironmentHandle, IntPtr array, int index, IntPtr val);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.SetObjectField))]
    public delegate void SetObjectField(IntPtr EnvironmentHandle, IntPtr obj, IntPtr jFieldId, IntPtr val);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.SetShortArrayRegion))]
    public delegate void SetShortArrayRegion(IntPtr EnvironmentHandle, IntPtr array, int start, int len, short* buf);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.SetShortField))]
    public delegate void SetShortField(IntPtr EnvironmentHandle, IntPtr obj, IntPtr jFieldId, short val);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.SetStaticBooleanField))]
    public delegate void SetStaticBooleanField(IntPtr EnvironmentHandle, IntPtr jniClass, IntPtr jFieldId, byte value);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.SetStaticByteField))]
    public delegate void SetStaticByteField(IntPtr EnvironmentHandle, IntPtr jniClass, IntPtr jFieldId, byte value);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.SetStaticCharField))]
    public delegate void SetStaticCharField(IntPtr EnvironmentHandle, IntPtr jniClass, IntPtr jFieldId, ushort value);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.SetStaticDoubleField))]
    public delegate void SetStaticDoubleField(IntPtr EnvironmentHandle, IntPtr jniClass, IntPtr jFieldId, double value);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.SetStaticFloatField))]
    public delegate void SetStaticFloatField(IntPtr EnvironmentHandle, IntPtr jniClass, IntPtr jFieldId, float value);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.SetStaticIntField))]
    public delegate void SetStaticIntField(IntPtr EnvironmentHandle, IntPtr jniClass, IntPtr jFieldId, int value);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.SetStaticLongField))]
    public delegate void SetStaticLongField(IntPtr EnvironmentHandle, IntPtr jniClass, IntPtr jFieldId, long value);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.SetStaticObjectField))]
    public delegate void SetStaticObjectField(IntPtr EnvironmentHandle, IntPtr jniClass, IntPtr jFieldId, IntPtr value);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.SetStaticShortField))]
    public delegate void SetStaticShortField(IntPtr EnvironmentHandle, IntPtr jniClass, IntPtr jFieldId, short value);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.Throw))]
    public delegate int Throw(IntPtr EnvironmentHandle, IntPtr obj);

    [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.ThrowNew))]
    public delegate int ThrowNew(IntPtr EnvironmentHandle, IntPtr jniClass, IntPtr msg);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.ToReflectedField))]
    public delegate IntPtr ToReflectedField(IntPtr EnvironmentHandle, IntPtr jniClass, IntPtr jFieldId, byte isStatic);

    [UnmanagedFunctionPointer(CallingConvention.Winapi),
     JNIFunctionBinding(nameof(JNINativeInterface.ToReflectedMethod))]
    public delegate IntPtr ToReflectedMethod(IntPtr EnvironmentHandle, IntPtr jniClass, IntPtr jMethodId,
        byte isStatic);
    
    // [UnmanagedFunctionPointer(CallingConvention.Winapi), JNIFunctionBinding(nameof(JNINativeInterface.UnregisterJavaPtrs))]
    // public delegate int UnregisterJavaPtrs(IntPtr EnvironmentHandle, IntPtr jniClass);
}