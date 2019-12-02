using Autofac;
using Autofac.Extensions.DependencyInjection;
using Blazored.Toast;
using BlazorPOC.Client;
using BlazorPOC.Configuration;
using BlazorPOC.Extensions;
using BlazorPOC.Modules;
using Common.Communication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BlazorPOC
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
            services.AddRazorPages();
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
        }

        #region Private Members

        public static IServiceProviderFactory<ContainerBuilder> ServiceProviderFactory = new AutofacServiceProviderFactory(cb => RegisterDependencies(cb));

        private static void RegisterDependencies(ContainerBuilder builder)
        {
            #region Register Modules

            builder.RegisterModule<ConfigurationModule>();

            #endregion

            #region Register Client

            var connection = BuildConnection();
            builder.RegisterInstance(new ServerProxy(connection)).As<IServerProxy>();
            builder.RegisterType<RoomReservationClient>().As<IRoomReservationClient>()
                .SingleInstance()
                .OnActivated(roomResClient => connection.ConfigureClient<IRoomReservationClient>(roomResClient.Instance));

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