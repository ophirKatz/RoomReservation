using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Common.Extensions
{
    public static class TypeExtensions
    {
        public static bool ImplementsInterface<TInterfaceType>(this Type type)
        {
            return type.GetInterface(typeof(TInterfaceType).Name) != null;
        }

        public static IEnumerable<MethodInfo> GetTypeDeclaredMethods(this Type type)
        {
            return type.GetMethods().Where(m => !m.IsSpecialName);
        }
    }
}