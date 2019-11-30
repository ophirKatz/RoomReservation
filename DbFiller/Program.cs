using Autofac;
using DAL.Configuration;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;

namespace DbFiller
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();

            var dataFileName = config["Reader:DataFileName"];

            var container = RegisterDependencies(config);
            
            var fillerFactory = container.Resolve<Func<string, DatabaseFiller>>();
            fillerFactory(dataFileName).FillDb();

            var logger = container.Resolve<ILogger>();

            logger.Information("Please press any key to finish the DbFiller process...");
            Console.ReadKey();
        }

        private static IContainer RegisterDependencies(IConfigurationRoot config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<JsonDataReader>().As<IDataReader>();
            builder.RegisterType<DatabaseFiller>().AsSelf();

            var dbConfig = config.GetSection(nameof(DatabaseConfiguration))
                  .Get<DatabaseConfiguration>();

            builder.Register<ILogger>((c, p) =>
            {
                return new LoggerConfiguration().WriteTo.Console().CreateLogger();
            }).SingleInstance();

            builder.RegisterInstance(dbConfig);

            return builder.Build();

        }
    }
}