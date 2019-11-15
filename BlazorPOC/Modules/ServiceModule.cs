using Autofac;
using BlazorPOC.Services;

namespace BlazorPOC.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ImmediateNameService>()
                .As<INameService>()
                .SingleInstance();
        }
    }
}