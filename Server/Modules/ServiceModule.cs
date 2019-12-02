using Autofac;
using Common.Extensions;
using System.Reflection;

namespace Server.Modules
{
    class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAllBySuffix(assembly, "Service");
            builder.RegisterAllBySuffix(assembly, "Converter");
        }
    }
}