using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Task2
{
    public static class ObjectExtensions
    {
        public static void SetReadOnlyProperty(this object obj, string propertyName, object newValue)
        {
            FieldInfo backingField = null;
            var objType = obj.GetType();
            var property = objType.GetProperty(propertyName);
            var baseType = objType.BaseType;
            if (property.Name == "Property" && baseType.Name != "Object")
            {
                backingField = baseType
                  .GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
                  .FirstOrDefault();
            }
            else
            {
                backingField = objType
                  .GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
                  .FirstOrDefault();
            }

            backingField.SetValue(obj, newValue);
        }

        public static void SetReadOnlyField(this object obj, string filedName, object newValue)
        {
            FieldInfo backingField = null;
            var objType = obj.GetType();
            var field = objType.GetField(filedName);
            var baseType = objType.BaseType;
            if (field.Name == "Filed" && baseType.Name != "Object")
            {
                backingField = baseType
                  .GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
                  .FirstOrDefault(f => f.Name == filedName);
            }
            else
            {
                backingField = objType
                  .GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
                  .FirstOrDefault(f => f.Name == filedName);
                  
            }

            backingField.SetValue(obj, newValue);
        }
    }
}
