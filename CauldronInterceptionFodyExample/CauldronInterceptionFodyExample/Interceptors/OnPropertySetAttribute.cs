using Cauldron.Interception;
using System;

namespace CauldronInterceptionFodyExample.Interceptors
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class OnPropertySetAttribute : Attribute, IPropertySetterInterceptor
    {
        [AssignMethod("{CtorArgument:0}")]
        public Action<string, object> onSetMethod = null;

        public OnPropertySetAttribute(string methodName)
        {
        }

        public void OnException(Exception e)
        {
        }

        public void OnExit()
        {
        }

        public bool OnSet(PropertyInterceptionInfo propertyInterceptionInfo, object oldValue, object newValue)
        {
            this.onSetMethod?.Invoke(propertyInterceptionInfo.PropertyName, newValue);
            return false;
        }
    }
}