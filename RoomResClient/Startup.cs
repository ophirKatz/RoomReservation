using Autofac;
using Autofac.Extensions.DependencyInjection;
using Blazored.Toast;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RoomResClient.Client;
using RoomResClient.Configuration;
using RoomResClient.Extensions;
using RoomResClient.Modules;
using Serilog;
using Shared.Communication;

namespace RoomResClient
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        static Startup()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();

            Config = config.GetSection(nameof(ServerConnectionConfiguration))
                    .Get<ServerConnectionConfiguration>();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages()
                .AddRazorPagesOptions(options =>
                {
                    options.RootDirectory = "/UI/Pages";
                });
            services.AddServerSideBlazor();
            services.AddSignalR();
            services.AddBlazoredToast();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

            app.ApplicationServices.GetService(typeof(IServerProxy));
        }

        #region Private Members

        public static IServiceProviderFactory<ContainerBuilder> ServiceProviderFactory = new AutofacServiceProviderFactory(cb => RegisterDependencies(cb));

        private static void RegisterDependencies(ContainerBuilder builder)
        {
            #region Register Modules

            builder.RegisterModule<ConfigurationModule>();

            #endregion

            #region Register Logger

            builder.Register<ILogger>((c, p) =>
            {
                // TODO : add log to file
                return new LoggerConfiguration().WriteTo.Console().CreateLogger();
            }).SingleInstance();

            #endregion

            #region Register Client

            var connection = BuildConnection();
            builder.RegisterInstance(connection).As<HubConnection>();
            builder.RegisterType<ServerProxy>().As<IServerProxy>().SingleInstance();
            builder.RegisterType<RoomReservationClient>().As<IRoomReservationClient>().SingleInstance();

            #endregion
        }

        private static HubConnection BuildConnection() => new HubConnectionBuilder()
            .WithAutomaticReconnect()
            .WithUrl($"http://{Config.ServerAddress}:{Config.ServerPort}/{Config.ServerHubName}")
            .Build();

        private static IServerConnectionConfiguration Config { get; set; }

        #endregion
    }
}