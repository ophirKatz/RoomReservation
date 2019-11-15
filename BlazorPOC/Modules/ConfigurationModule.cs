using Autofac;
using BlazorPOC.Configuration;
using Microsoft.Extensions.Configuration;

namespace BlazorPOC.Modules
{
    public class ConfigurationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();

            var appConfiguration = config.GetSection(nameof(AppConfiguration))
                .Get<AppConfiguration>();

            builder.RegisterInstance(appConfiguration)
                .As<IAppConfiguration>();
        }
    }
}