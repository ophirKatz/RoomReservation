using Common.Communication;
using Common.Data;
using System.Threading.Tasks;

namespace BlazorPOC.Client
{
    public class WeatherClient : IWeatherClient
    {
        public WeatherClient(IWeatherForecastModel weatherForecastModel)
        {
            WeatherForecastModel = weatherForecastModel;
        }

        public Task ReceiveWeatherForecast(WeatherForecast[] weatherForcasts)
        {
            WeatherForecastModel.WeatherForecasts = weatherForcasts;
            return Task.CompletedTask;
        }

        public IWeatherForecastModel WeatherForecastModel { get; set; }
    }
}