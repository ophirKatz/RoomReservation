using Autofac;
using Microsoft.Extensions.Configuration;
using Server.Configuration;

namespace Server.Modules
{
    public class ConfigurationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var dbConfig = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build()
                .GetSection(nameof(DatabaseConfiguration))
                .Get<DatabaseConfiguration>();

            builder.RegisterInstance(dbConfig)
                .As<IDatabaseConfiguration>();
        }
    }
}