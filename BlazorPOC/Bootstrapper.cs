using Autofac;
using BlazorPOC.Client;
using BlazorPOC.Extensions;
using BlazorPOC.Modules;
using Common.Communication;
using Common.Data;
using Common.Extensions;
using Microsoft.AspNetCore.SignalR.Client;
using System.Threading.Tasks;

namespace BlazorPOC
{
    public class Bootstrapper
    {
        public void RegisterDependencies(ContainerBuilder builder)
        {
            builder.RegisterModule<ConfigurationModule>();

            builder.RegisterType<WeatherForecastModel>().As<IWeatherForecastModel>().SingleInstance();

            #region Register Client

            var connection = BuildConnection();
            builder.RegisterInstance(new ServerProxy(connection)).As<IServerProxy>();
            builder.RegisterType<WeatherClient>().As<IWeatherClient>()
                .SingleInstance()
                .OnActivated(weatherClient => connection.ConfigureClient<IWeatherClient>(weatherClient.Instance));

            #endregion
        }

        private HubConnection BuildConnection()
        {
            // TODO : Configure URL
            return new HubConnectionBuilder()
                .WithAutomaticReconnect()
                .WithUrl($"http://localhost:8080/{HubName}")
                .Build();
        }

        // TODO : Configure
        private const string HubName = "weatherHub";
    }
}