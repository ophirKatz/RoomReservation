using System;
using System.Reflection;

namespace BlazorPOC.Extensions
{
    public static class MethodInfoExtensions
    {
        public static Type[] GetParameterTypes(this MethodInfo methodInfo)
        {
            var parameters = methodInfo.GetParameters();
            var parameterTypes = new Type[parameters.Length];
            for (var i = 0; i < parameters.Length; i++)
            {
                parameterTypes[i] = parameters[i].ParameterType;
            }

            return parameterTypes;
        }
    }
}