using Autofac;
using BlazorPOC.Modules;

namespace BlazorPOC
{
    public class Bootstrapper
    {
        public void RegisterDependencies(ContainerBuilder builder)
        {
            builder.RegisterModule<ConfigurationModule>();
            builder.RegisterModule<ServiceModule>();
        }
    }
}