﻿using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Server.Configuration;

namespace Server.Server
{
    public class Server
    {
        public Server()
        {
            ServerConfiguration = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build()
                .GetSection(nameof(ServerConfiguration))
                .Get<ServerConfiguration>();
        }

        public void Start()
        {
            var host = Host.CreateDefaultBuilder()
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(ServerHostConfiguration)
                .ConfigureLogging(logging =>
                {
                    logging.AddFilter("Microsoft.AspNetCore.SignalR", LogLevel.Debug);
                    logging.AddFilter("Microsoft.AspNetCore.Http.Connections", LogLevel.Debug);
                })
                .Build();

            host.Run();

            void ServerHostConfiguration(IWebHostBuilder webHostBuilder)
            {
                webHostBuilder
                    .UseUrls(ServerConfiguration.ServerAddress)
                    .UseStartup<Startup>();
            }
        }

        private IServerConfiguration ServerConfiguration { get; set; }
    }
}