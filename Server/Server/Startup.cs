using Autofac;
using DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Server.Hubs;
using Server.Modules;
using System.Reflection;

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
            services.AddDbContext<ServerDbContext>();
        }

        // ConfigureContainer is where you can register things directly
        // with Autofac. This runs after ConfigureServices so the things
        // here will override registrations made in ConfigureServices.
        // Don't build the container; that gets done for you by the factory.
        public void ConfigureContainer(ContainerBuilder builder)
        {
            #region Register Modules

            /* builder.RegisterModule<ServiceModule>();
            builder.RegisterModule<DtoModule>();
            builder.RegisterModule<ConfigurationModule>();
            builder.RegisterModule<ModelModule>(); */
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

            #endregion

            #region Register Logger

            builder.Register<ILogger>((c, p) =>
            {
                // TODO : add log to file
                return new LoggerConfiguration().WriteTo.Console().CreateLogger();
            }).SingleInstance();

            #endregion

            #region Register Server

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
                routeBuilder.MapHub<RoomReservationHub>($"/{nameof(RoomReservationHub)}");
            });
        }
    }
}