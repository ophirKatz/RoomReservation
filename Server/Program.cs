using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Server.Configuration;
using Server.Server;

namespace Server
{
    class Program
    {
        public static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder()
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(ServerHostConfiguration)
                .Build();

            // Resolve the server
            host.Services.GetService(typeof(IClientRequestHandler));

            host.Run();

            static void ServerHostConfiguration(IWebHostBuilder webHostBuilder)
            { 
                webHostBuilder
                    .UseUrls(Configuration.ServerAddress)
                    .UseStartup<Startup>();
            }
        }

        private static ServerConfiguration Configuration => new ConfigurationBuilder()
            .AddJsonFile("config.json")
            .Build()
            .GetSection(nameof(ServerConfiguration))
            .Get<ServerConfiguration>();
    }
}