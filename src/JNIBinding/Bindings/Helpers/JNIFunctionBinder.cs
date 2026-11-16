using System.Diagnostics;
using System.Reflection;
using JNIBinding.Bindings.Native;
using JNIBinding.Diagnostics;

namespace JNIBinding;

public static class JNIFunctionBinder
{
    public static void Bind(JNIInvokeBridge bindingTarget, JNIInvokeInterface pointerContainer)
    {
        var sw = new Stopwatch();
        JniLog.Trace("JNIFunctionBinder", $"Binding {bindingTarget} with {pointerContainer}");

        var bindingTargetType = bindingTarget.GetType();
        var bindingTargetRef = bindingTargetType.GetField(nameof(JNIInvokeBridge._binding));
        var functionPointers = pointerContainer.GetType();

        var bindingProperties = bindingTargetType.GetProperties()
            .Where(s => s.GetCustomAttribute<JNIFunctionBindingAttribute>() != null)
            .Select(s => (s.GetCustomAttribute<JNIFunctionBindingAttribute>(), s))
            .ToList();

        var wrapFunc = typeof(JVM).GetMethod(nameof(JVM.Wrap));
        foreach (var (binding, bindingProperty) in bindingProperties)
        {
            JniLog.Trace("JNIFunctionBinder", $"Binding {bindingTarget}.{binding.Target} to {pointerContainer}.{bindingProperty.Name}");

            // Convert a given nint/IntPtr function pointer to a wrapped Delegate via JEnv.Wrap<T>()
            object? fpToDelegate(Type t, IntPtr fp)
            {
                JniLog.Trace("JNIFunctionBinder", $"Wrapping delegate* [{fp}] of {t.Name}");
                return wrapFunc.MakeGenericMethod(t).Invoke(null, [fp]);
            }

            // Set the bindingProperty on bindingTarget to the function pointer delegate retrieved from
            // bindingSource
            void SetBridgeFunc(object ptr, IntPtr val)
            {
                JniLog.Trace("JNIFunctionBinder", $"Setting {ptr}.{bindingProperty.Name} to {functionPointers.Name}.{binding.Target} [{val}]");
                bindingProperty.SetValue(ptr, fpToDelegate(bindingProperty.PropertyType, val));
            }

            /* Retrieve the IntPtr function pointer from the pointerContainer
             * Retrieve the JNIInvokeInterface member field from bindingTarget
             * Retrieve the IntPtr field from pointerContainer via the bindingTarget.Binding
             */
            
            // The IntPtr from pointerContainer we want to use
            var sourceField = functionPointers.GetField(binding.Target);
            Debug.Assert(sourceField != null,
                $"Unable to find field {binding?.Target} on {functionPointers.Name}");
            
            // The JNIInvokeInterface field from bindingTarget
            var targetRef = bindingTargetRef?.GetValue(bindingTarget);
            Debug.Assert(targetRef != null,$"Unable to retrieve value for {bindingTargetRef?.Name}");
            
            // The delegate* from JNIInvokeInterface via bindingTargets.Binding
            var functionPointer = (IntPtr)sourceField.GetValue(targetRef)!;
            Debug.Assert(functionPointer != IntPtr.Zero, $"Could not convert {targetRef} to delegate");

            // Finally go set the property
            SetBridgeFunc(bindingTarget, functionPointer);
            JniLog.Trace("JNIFunctionBinder", $"Bound {bindingTarget}.{binding.Target} to {functionPointer:x8})");
        }

        sw.Stop();
        JniLog.Trace("JNIFunctionBinder", $"Bound {bindingProperties.Count()} function pointers in {sw.Elapsed:g}");
    } 
    
    // TODO: Probably replace this with codegen'ed automatic binding, same attribute just do it at compile time
    public static void Bind(JNIFunctionBridge bindingTarget, JNINativeInterface pointerContainer)
    {
        var sw = new Stopwatch();
        sw.Start();
        JniLog.Trace("JNIFunctionBinder", $"Binding {bindingTarget} with {pointerContainer}");

        var bindingTargetType = bindingTarget.GetType();
        var bindingTargetRef = bindingTargetType.GetField(nameof(JNIFunctionBridge._binding));
        var functionPointers = pointerContainer.GetType();

        var bindingProperties = bindingTargetType.GetProperties()
            .Where(s => s.GetCustomAttribute<JNIFunctionBindingAttribute>() != null)
            .Select(s => (s.GetCustomAttribute<JNIFunctionBindingAttribute>(), s))
            .ToList();

        var wrapFunc = typeof(JNIEnv).GetMethod(nameof(JNIEnv.Wrap));
        foreach (var (binding, bindingProperty) in bindingProperties)
        {
            JniLog.Trace("JNIFunctionBinder", $"Binding {bindingTarget}.{binding.Target} to {pointerContainer}.{bindingProperty.Name}");

            // Convert a given nint/IntPtr function pointer to a wrapped Delegate via JEnv.Wrap<T>()
            object? fpToDelegate(Type t, IntPtr fp)
            {
                JniLog.Trace("JNIFunctionBinder", $"Wrapping delegate* [{fp}] of {t.Name}");
                return wrapFunc.MakeGenericMethod(t).Invoke(null, [fp]);
            }

            // Set the bindingProperty on bindingTarget to the function pointer delegate retrieved from
            // bindingSource
            void SetBridgeFunc(object ptr, IntPtr val)
            {
                JniLog.Trace("JNIFunctionBinder", $"Setting {ptr}.{bindingProperty.Name} to {functionPointers.Name}.{binding.Target} [{val}]");
                bindingProperty.SetValue(ptr, fpToDelegate(bindingProperty.PropertyType, val));
            }

            /* Retrieve the IntPtr function pointer from the pointerContainer
             * Retrieve the JNINativeInterface member field from bindingTarget
             * Retrieve the IntPtr field from pointerContainer via the bindingTarget.Binding
             */
            
            // The IntPtr from pointerContainer we want to use
            var sourceField = functionPointers.GetField(binding.Target);
            Debug.Assert(sourceField != null,
                $"Unable to find field {binding?.Target} on {functionPointers.Name}");
            
            // The JNINativeInterface field from bindingTarget
            var targetRef = bindingTargetRef?.GetValue(bindingTarget);
            Debug.Assert(targetRef != null,$"Unable to retrieve value for {bindingTargetRef?.Name}");
            
            // The delegate* from JNINativeInterface via bindingTargets.Binding
            var functionPointer = (IntPtr)sourceField.GetValue(targetRef)!;
            Debug.Assert(functionPointer != IntPtr.Zero, $"Could not convert {targetRef} to delegate");

            // Finally go set the property
            SetBridgeFunc(bindingTarget, functionPointer);
            JniLog.Trace("JNIFunctionBinder", $"Bound {bindingTarget}.{binding.Target} to {functionPointer:x8})");
        }

        sw.Stop();
        JniLog.Trace("JNIFunctionBinder", $"Bound {bindingProperties.Count()} function pointers in {sw.Elapsed:g}");
    }
}