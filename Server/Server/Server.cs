using Microsoft.AspNetCore.Hosting;
using System;

namespace Server.Server
{
    public class Server : IServer
    {
        public Server()
        {

        }

        public void Start()
        {
            // TODO : Configure
            var url = "localhost:8080";

            var host = new WebHostBuilder()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}