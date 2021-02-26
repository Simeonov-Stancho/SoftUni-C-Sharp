using System;
using System.Linq;
using System.Reflection;


namespace MiniORMCore
{
    internal static class ReflectionHelper
    {
        // Replaces an auto-generated backing field with an object instance.
        // Commonly used to set properties without a setter.

        public static void ReplaceBackingField(object sourceObj, string propertyName, object targetObj)
        {
            var backingField = sourceObj.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetField)
                .First(fi => fi.Name == $"<{propertyName}>k__BackingField");

            backingField.SetValue(sourceObj, targetObj);
        }

        /// Extension method for MemberInfo, which checks if a member contains an attribute.

        public static bool HasAttribute<T>(this MemberInfo mi)
            where T : Attribute
        {
            var hasAttribute = mi.GetCustomAttribute<T>() != null;
            return hasAttribute;
        }
    }
}
