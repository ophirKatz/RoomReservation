using Autofac;
using System.Reflection;

namespace Shared.Extensions
{
    public static class ContainerBuilderExtensions
    {
        public static void RegisterAllBySuffix(this ContainerBuilder builder, Assembly assembly, string suffix)
        {
            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith(suffix))
                .AsImplementedInterfaces();
        }
    }
}