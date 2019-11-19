using Common.Communication;
using Common.Data;
using System;
using System.Threading.Tasks;

namespace BlazorPOC.Client
{
    public class WeatherClient : IWeatherClient
    {
        public WeatherClient(IWeatherForecastModel weatherForecastModel,
            IConnectedServerModel connectedServerModel)
        {
            WeatherForecastModel = weatherForecastModel;
            ConnectedServerModel = connectedServerModel;
        }

        public Task ReceiveWeatherForecast(WeatherForecast[] weatherForcasts)
        {
            WeatherForecastModel.WeatherForecasts = weatherForcasts;
            return Task.CompletedTask;
        }

        public Task ReceiveWeatherServerName(string oldName, string newName)
        {
            ConnectedServerModel.ServerName = newName;
            Console.WriteLine($"{nameof(oldName)}: {oldName}, {nameof(newName)}: {newName}");
            return Task.CompletedTask;
        }

        public IWeatherForecastModel WeatherForecastModel { get; set; }
        public IConnectedServerModel ConnectedServerModel { get; }
    }
}