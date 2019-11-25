using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Server.Hubs;
using Server.Modules;

namespace Server.Server
{
    public class Startup
    {
        // ConfigureServices is where you register dependencies. This gets
        // called by the runtime before the ConfigureContainer method, below.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the collection. Don't build or return
            // any IServiceProvider or the ConfigureContainer method
            // won't get called.
            services.AddSignalR();
        }

        // ConfigureContainer is where you can register things directly
        // with Autofac. This runs after ConfigureServices so the things
        // here will override registrations made in ConfigureServices.
        // Don't build the container; that gets done for you by the factory.
        public void ConfigureContainer(ContainerBuilder builder)
        {
            #region Register Modules

            builder.RegisterModule<ServiceModule>();

            #endregion

            #region Register Server

            builder.RegisterType<WeatherForecastHub>().AsSelf();
            builder.RegisterType<ClientRequestHandler>().As<IClientRequestHandler>().SingleInstance();

            #endregion
        }

        // Configure is where you add middleware. This is called after
        // ConfigureContainer. You can use IApplicationBuilder.ApplicationServices
        // here if you need to resolve things from the container.
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseEndpoints(routeBuilder =>
            {
                routeBuilder.MapHub<WeatherForecastHub>("weatherHub");
            });
        }
    }
}