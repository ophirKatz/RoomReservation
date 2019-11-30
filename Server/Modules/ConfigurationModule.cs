using Autofac;
using DAL.Configuration;
using Microsoft.Extensions.Configuration;

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