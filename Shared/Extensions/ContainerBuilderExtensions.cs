using Autofac;
using Autofac.Builder;
using System.Reflection;

namespace Shared.Extensions
{
    public static class ContainerBuilderExtensions
    {
        public static IRegistrationBuilder<object, Autofac.Features.Scanning.ScanningActivatorData, DynamicRegistrationStyle>
            RegisterAllBySuffix(this ContainerBuilder builder, Assembly assembly, string suffix)
        {
            return builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith(suffix))
                .AsImplementedInterfaces();
        }

        public static void RegisterAllBySuffixSingleInstance(this ContainerBuilder builder, Assembly assembly, string suffix)
        {
            builder.RegisterAllBySuffix(assembly, suffix)
                .SingleInstance();
        }
    }
}