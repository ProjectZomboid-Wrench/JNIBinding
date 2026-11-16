using JNIBinding;
using JNIBinding.Bindings;
using JNIBinding.Bindings.Native.Types;

var runtime = JavaRuntime.Bootstrap(new JvmLibrary());
var jEnv = runtime.Env;
Console.WriteLine($"VM: {runtime.VM} Env: {jEnv.EnvHandle}");

var clsPtr = jEnv.FindClass("java/lang/Object");
Console.WriteLine($"Fetched ref: {clsPtr}");

var objArrayPtr = jEnv.NewObjectArray(1, clsPtr, _JObject.Null);
Console.WriteLine($"Created array: {objArrayPtr}");

var jobjInst = new _JObject(jEnv.Functions.AllocObject(jEnv, clsPtr));
Console.WriteLine($"Alloc'ed {jobjInst}");

jEnv.SetObjectArrayElement(objArrayPtr, 0, jobjInst);
var obj = jEnv.GetObjectArrayElement(objArrayPtr, 0);
Console.WriteLine($"Fetched {objArrayPtr}[0] = {obj}");
