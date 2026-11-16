using JNIBinding.Bindings.Native;

namespace JNIBinding;

public class JNIFunctionBridge(JNINativeInterface functions)
{
    // Hold a reference to the binding target here
    public readonly JNINativeInterface _binding = functions;

    /* Generated Code
        Converted from JNINativeInterface_ via 
        `[\w]+\b\s[\w]+\b\s[\w]+\s([\w]+)`
        `[JNIFunctionBinding(nameof(JNINativeInterface_.$1))]\npublic JNINativeInterface_.$1 $1 { get; init; }\n\n`
     */

    // Delegates taking _JValue* must bind to the *A slots; the unsuffixed slots are C varargs.
    [JNIFunctionBinding(nameof(JNINativeInterface_.AllocObject))]
    public JNINativeInterface_.AllocObject AllocObject { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface.CallBooleanMethodA))]
    public JNINativeInterface_.CallBooleanMethod CallBooleanMethod { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface.CallByteMethodA))]
    public JNINativeInterface_.CallByteMethod CallByteMethod { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface.CallCharMethodA))]
    public JNINativeInterface_.CallCharMethod CallCharMethod { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface.CallDoubleMethodA))]
    public JNINativeInterface_.CallDoubleMethod CallDoubleMethod { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface.CallFloatMethodA))]
    public JNINativeInterface_.CallFloatMethod CallFloatMethod { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface.CallIntMethodA))]
    public JNINativeInterface_.CallIntMethod CallIntMethod { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface.CallLongMethodA))]
    public JNINativeInterface_.CallLongMethod CallLongMethod { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface.CallObjectMethodA))]
    public JNINativeInterface_.CallObjectMethod CallObjectMethod { get; init; }
    
    [JNIFunctionBinding(nameof(JNINativeInterface_.CallObjectMethodA))]
    public JNINativeInterface_.CallObjectMethodA CallObjectMethodA { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface.CallShortMethodA))]
    public JNINativeInterface_.CallShortMethod CallShortMethod { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface.CallVoidMethodA))]
    public JNINativeInterface_.CallVoidMethod CallVoidMethod { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface.CallNonvirtualBooleanMethodA))]
    public JNINativeInterface_.CallNonvirtualBooleanMethod CallNonvirtualBooleanMethod { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface.CallNonvirtualByteMethodA))]
    public JNINativeInterface_.CallNonvirtualByteMethod CallNonvirtualByteMethod { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface.CallNonvirtualCharMethodA))]
    public JNINativeInterface_.CallNonvirtualCharMethod CallNonvirtualCharMethod { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface.CallNonvirtualDoubleMethodA))]
    public JNINativeInterface_.CallNonvirtualDoubleMethod CallNonvirtualDoubleMethod { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface.CallNonvirtualFloatMethodA))]
    public JNINativeInterface_.CallNonvirtualFloatMethod CallNonvirtualFloatMethod { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface.CallNonvirtualIntMethodA))]
    public JNINativeInterface_.CallNonvirtualIntMethod CallNonvirtualIntMethod { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface.CallNonvirtualLongMethodA))]
    public JNINativeInterface_.CallNonvirtualLongMethod CallNonvirtualLongMethod { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface.CallNonvirtualObjectMethodA))]
    public JNINativeInterface_.CallNonvirtualObjectMethod CallNonvirtualObjectMethod { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface.CallNonvirtualShortMethodA))]
    public JNINativeInterface_.CallNonvirtualShortMethod CallNonvirtualShortMethod { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface.CallNonvirtualVoidMethodA))]
    public JNINativeInterface_.CallNonvirtualVoidMethod CallNonvirtualVoidMethod { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface.CallStaticBooleanMethodA))]
    public JNINativeInterface_.CallStaticBooleanMethod CallStaticBooleanMethod { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface.CallStaticByteMethodA))]
    public JNINativeInterface_.CallStaticByteMethod CallStaticByteMethod { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface.CallStaticCharMethodA))]
    public JNINativeInterface_.CallStaticCharMethod CallStaticCharMethod { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface.CallStaticDoubleMethodA))]
    public JNINativeInterface_.CallStaticDoubleMethod CallStaticDoubleMethod { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface.CallStaticFloatMethodA))]
    public JNINativeInterface_.CallStaticFloatMethod CallStaticFloatMethod { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface.CallStaticIntMethodA))]
    public JNINativeInterface_.CallStaticIntMethod CallStaticIntMethod { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface.CallStaticLongMethodA))]
    public JNINativeInterface_.CallStaticLongMethod CallStaticLongMethod { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface.CallStaticObjectMethodA))]
    public JNINativeInterface_.CallStaticObjectMethod CallStaticObjectMethod { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface.CallStaticShortMethodA))]
    public JNINativeInterface_.CallStaticShortMethod CallStaticShortMethod { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface.CallStaticVoidMethodA))]
    public JNINativeInterface_.CallStaticVoidMethod CallStaticVoidMethod { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.DefineClass))]
    public JNINativeInterface_.DefineClass DefineClass { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.DeleteGlobalRef))]
    public JNINativeInterface_.DeleteGlobalRef DeleteGlobalRef { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.DeleteLocalRef))]
    public JNINativeInterface_.DeleteLocalRef DeleteLocalRef { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.DeleteWeakGlobalRef))]
    public JNINativeInterface_.DeleteWeakGlobalRef DeleteWeakGlobalRef { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.EnsureLocalCapacity))]
    public JNINativeInterface_.EnsureLocalCapacity EnsureLocalCapacity { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.ExceptionCheck))]
    public JNINativeInterface_.ExceptionCheck ExceptionCheck { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.ExceptionClear))]
    public JNINativeInterface_.ExceptionClear ExceptionClear { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.ExceptionDescribe))]
    public JNINativeInterface_.ExceptionDescribe ExceptionDescribe { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.ExceptionOccurred))]
    public JNINativeInterface_.ExceptionOccurred ExceptionOccurred { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.FatalError))]
    public JNINativeInterface_.FatalError FatalError { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.FindClass))]
    public JNINativeInterface_.FindClass FindClass { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetSuperclass))]
    public JNINativeInterface_.GetSuperclass GetSuperclass { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.IsAssignableFrom))]
    public JNINativeInterface_.IsAssignableFrom IsAssignableFrom { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.FromReflectedField))]
    public JNINativeInterface_.FromReflectedField FromReflectedField { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.FromReflectedMethod))]
    public JNINativeInterface_.FromReflectedMethod FromReflectedMethod { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetArrayLength))]
    public JNINativeInterface_.GetArrayLength GetArrayLength { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetBooleanArrayRegion))]
    public JNINativeInterface_.GetBooleanArrayRegion GetBooleanArrayRegion { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetBooleanField))]
    public JNINativeInterface_.GetBooleanField GetBooleanField { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetByteArrayRegion))]
    public JNINativeInterface_.GetByteArrayRegion GetByteArrayRegion { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetByteField))]
    public JNINativeInterface_.GetByteField GetByteField { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetCharArrayRegion))]
    public JNINativeInterface_.GetCharArrayRegion GetCharArrayRegion { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetCharField))]
    public JNINativeInterface_.GetCharField GetCharField { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetDirectBufferAddress))]
    public JNINativeInterface_.GetDirectBufferAddress GetDirectBufferAddress { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetDirectBufferCapacity))]
    public JNINativeInterface_.GetDirectBufferCapacity GetDirectBufferCapacity { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetDoubleArrayRegion))]
    public JNINativeInterface_.GetDoubleArrayRegion GetDoubleArrayRegion { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetDoubleField))]
    public JNINativeInterface_.GetDoubleField GetDoubleField { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetFieldID))]
    public JNINativeInterface_.GetFieldID GetFieldID { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetFloatArrayRegion))]
    public JNINativeInterface_.GetFloatArrayRegion GetFloatArrayRegion { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetFloatField))]
    public JNINativeInterface_.GetFloatField GetFloatField { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetIntArrayRegion))]
    public JNINativeInterface_.GetIntArrayRegion GetIntArrayRegion { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetIntField))]
    public JNINativeInterface_.GetIntField GetIntField { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetJavaVM))]
    public JNINativeInterface_.GetJavaVM GetJavaVM { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetLongArrayRegion))]
    public JNINativeInterface_.GetLongArrayRegion GetLongArrayRegion { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetLongField))]
    public JNINativeInterface_.GetLongField GetLongField { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetMethodID))]
    public JNINativeInterface_.GetMethodID GetMethodID { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetObjectArrayElement))]
    public JNINativeInterface_.GetObjectArrayElement GetObjectArrayElement { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetObjectClass))]
    public JNINativeInterface_.GetObjectClass GetObjectClass { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetObjectField))]
    public JNINativeInterface_.GetObjectField GetObjectField { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetShortArrayRegion))]
    public JNINativeInterface_.GetShortArrayRegion GetShortArrayRegion { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetShortField))]
    public JNINativeInterface_.GetShortField GetShortField { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetStaticBooleanField))]
    public JNINativeInterface_.GetStaticBooleanField GetStaticBooleanField { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetStaticByteField))]
    public JNINativeInterface_.GetStaticByteField GetStaticByteField { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetStaticCharField))]
    public JNINativeInterface_.GetStaticCharField GetStaticCharField { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetStaticDoubleField))]
    public JNINativeInterface_.GetStaticDoubleField GetStaticDoubleField { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetStaticFieldID))]
    public JNINativeInterface_.GetStaticFieldID GetStaticFieldID { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetStaticFloatField))]
    public JNINativeInterface_.GetStaticFloatField GetStaticFloatField { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetStaticIntField))]
    public JNINativeInterface_.GetStaticIntField GetStaticIntField { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetStaticLongField))]
    public JNINativeInterface_.GetStaticLongField GetStaticLongField { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetStaticMethodID))]
    public JNINativeInterface_.GetStaticMethodID GetStaticMethodID { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetStaticObjectField))]
    public JNINativeInterface_.GetStaticObjectField GetStaticObjectField { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetStaticShortField))]
    public JNINativeInterface_.GetStaticShortField GetStaticShortField { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetStringChars))]
    public JNINativeInterface_.GetStringChars GetStringChars { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetStringCritical))]
    public JNINativeInterface_.GetStringCritical GetStringCritical { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetStringLength))]
    public JNINativeInterface_.GetStringLength GetStringLength { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetStringRegion))]
    public JNINativeInterface_.GetStringRegion GetStringRegion { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetStringUTFChars))]
    public JNINativeInterface_.GetStringUTFChars GetStringUTFChars { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetStringUTFLength))]
    public JNINativeInterface_.GetStringUTFLength GetStringUTFLength { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetStringUTFRegion))]
    public JNINativeInterface_.GetStringUTFRegion GetStringUTFRegion { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.GetVersion))]
    public JNINativeInterface_.GetVersion GetVersion { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.IsSameObject))]
    public JNINativeInterface_.IsSameObject IsSameObject { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.IsInstanceOf))]
    public JNINativeInterface_.IsInstanceOf IsInstanceOf { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.MonitorEnter))]
    public JNINativeInterface_.MonitorEnter MonitorEnter { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.MonitorExit))]
    public JNINativeInterface_.MonitorExit MonitorExit { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.NewBooleanArray))]
    public JNINativeInterface_.NewBooleanArray NewBooleanArray { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.NewByteArray))]
    public JNINativeInterface_.NewByteArray NewByteArray { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.NewCharArray))]
    public JNINativeInterface_.NewCharArray NewCharArray { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.NewDirectByteBuffer))]
    public JNINativeInterface_.NewDirectByteBuffer NewDirectByteBuffer { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.NewDoubleArray))]
    public JNINativeInterface_.NewDoubleArray NewDoubleArray { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.NewFloatArray))]
    public JNINativeInterface_.NewFloatArray NewFloatArray { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.NewGlobalRef))]
    public JNINativeInterface_.NewGlobalRef NewGlobalRef { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.NewIntArray))]
    public JNINativeInterface_.NewIntArray NewIntArray { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.NewLocalRef))]
    public JNINativeInterface_.NewLocalRef NewLocalRef { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.NewLongArray))]
    public JNINativeInterface_.NewLongArray NewLongArray { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface.NewObjectA))]
    public JNINativeInterface_.NewObject NewObject { get; init; }
    
    [JNIFunctionBinding(nameof(JNINativeInterface_.NewObjectA))]
    public JNINativeInterface_.NewObjectA NewObjectA { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.NewObjectArray))]
    public JNINativeInterface_.NewObjectArray NewObjectArray { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.NewShortArray))]
    public JNINativeInterface_.NewShortArray NewShortArray { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.NewString))]
    public JNINativeInterface_.NewString NewString { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.NewStringUTF))]
    public JNINativeInterface_.NewStringUTF NewStringUTF { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.NewWeakGlobalRef))]
    public JNINativeInterface_.NewWeakGlobalRef NewWeakGlobalRef { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.PopLocalFrame))]
    public JNINativeInterface_.PopLocalFrame PopLocalFrame { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.PushLocalFrame))]
    public JNINativeInterface_.PushLocalFrame PushLocalFrame { get; init; }
    
    [JNIFunctionBinding(nameof(JNINativeInterface_.RegisterNatives))]
    public JNINativeInterface_.RegisterNatives RegisterNatives { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.UnregisterNatives))]
    public JNINativeInterface_.UnregisterNatives UnregisterNatives { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.ReleaseBooleanArrayElements))]
    public JNINativeInterface_.ReleaseBooleanArrayElements ReleaseBooleanArrayElements { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.ReleaseByteArrayElements))]
    public JNINativeInterface_.ReleaseByteArrayElements ReleaseByteArrayElements { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.ReleaseDoubleArrayElements))]
    public JNINativeInterface_.ReleaseDoubleArrayElements ReleaseDoubleArrayElements { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.ReleaseIntArrayElements))]
    public JNINativeInterface_.ReleaseIntArrayElements ReleaseIntArrayElements { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.ReleaseLongArrayElements))]
    public JNINativeInterface_.ReleaseLongArrayElements ReleaseLongArrayElements { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.ReleasePrimitiveArrayCritical))]
    public JNINativeInterface_.ReleasePrimitiveArrayCritical ReleasePrimitiveArrayCritical { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.ReleaseStringChars))]
    public JNINativeInterface_.ReleaseStringChars ReleaseStringChars { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.ReleaseStringCritical))]
    public JNINativeInterface_.ReleaseStringCritical ReleaseStringCritical { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.ReleaseStringUTFChars))]
    public JNINativeInterface_.ReleaseStringUTFChars ReleaseStringUTFChars { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.SetBooleanArrayRegion))]
    public JNINativeInterface_.SetBooleanArrayRegion SetBooleanArrayRegion { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.SetBooleanField))]
    public JNINativeInterface_.SetBooleanField SetBooleanField { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.SetByteArrayRegion))]
    public JNINativeInterface_.SetByteArrayRegion SetByteArrayRegion { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.SetByteField))]
    public JNINativeInterface_.SetByteField SetByteField { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.SetCharArrayRegion))]
    public JNINativeInterface_.SetCharArrayRegion SetCharArrayRegion { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.SetCharField))]
    public JNINativeInterface_.SetCharField SetCharField { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.SetDoubleArrayRegion))]
    public JNINativeInterface_.SetDoubleArrayRegion SetDoubleArrayRegion { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.SetDoubleField))]
    public JNINativeInterface_.SetDoubleField SetDoubleField { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.SetFloatArrayRegion))]
    public JNINativeInterface_.SetFloatArrayRegion SetFloatArrayRegion { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.SetFloatField))]
    public JNINativeInterface_.SetFloatField SetFloatField { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.SetIntArrayRegion))]
    public JNINativeInterface_.SetIntArrayRegion SetIntArrayRegion { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.SetIntField))]
    public JNINativeInterface_.SetIntField SetIntField { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.SetLongArrayRegion))]
    public JNINativeInterface_.SetLongArrayRegion SetLongArrayRegion { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.SetLongField))]
    public JNINativeInterface_.SetLongField SetLongField { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.SetObjectArrayElement))]
    public JNINativeInterface_.SetObjectArrayElement SetObjectArrayElement { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.SetObjectField))]
    public JNINativeInterface_.SetObjectField SetObjectField { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.SetShortArrayRegion))]
    public JNINativeInterface_.SetShortArrayRegion SetShortArrayRegion { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.SetShortField))]
    public JNINativeInterface_.SetShortField SetShortField { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.SetStaticBooleanField))]
    public JNINativeInterface_.SetStaticBooleanField SetStaticBooleanField { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.SetStaticByteField))]
    public JNINativeInterface_.SetStaticByteField SetStaticByteField { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.SetStaticCharField))]
    public JNINativeInterface_.SetStaticCharField SetStaticCharField { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.SetStaticDoubleField))]
    public JNINativeInterface_.SetStaticDoubleField SetStaticDoubleField { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.SetStaticFloatField))]
    public JNINativeInterface_.SetStaticFloatField SetStaticFloatField { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.SetStaticIntField))]
    public JNINativeInterface_.SetStaticIntField SetStaticIntField { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.SetStaticLongField))]
    public JNINativeInterface_.SetStaticLongField SetStaticLongField { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.SetStaticObjectField))]
    public JNINativeInterface_.SetStaticObjectField SetStaticObjectField { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.SetStaticShortField))]
    public JNINativeInterface_.SetStaticShortField SetStaticShortField { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.Throw))]
    public JNINativeInterface_.Throw Throw { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.ThrowNew))]
    public JNINativeInterface_.ThrowNew ThrowNew { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.ToReflectedField))]
    public JNINativeInterface_.ToReflectedField ToReflectedField { get; init; }

    [JNIFunctionBinding(nameof(JNINativeInterface_.ToReflectedMethod))]
    public JNINativeInterface_.ToReflectedMethod ToReflectedMethod { get; init; }

    // [JNIFunctionBinding(nameof(JNINativeInterface_.UnregisterJavaPtrs))]
    // public JNINativeInterface_.UnregisterJavaPtrs UnregisterJavaPtrs { get; init; }
}