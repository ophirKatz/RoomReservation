using Common.Data;
using Server.Services;
using System;
using System.Threading.Tasks;

namespace Server.Server
{
    public class ClientRequestHandler : IClientRequestHandler
    {
        public ClientRequestHandler(IWeatherForecastService weatherForecastService)
        {
            WeatherForecastService = weatherForecastService;
        }

        public async Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            return await WeatherForecastService.GetForecastAsync(startDate)
                .ConfigureAwait(false);
        }

        public async Task<string> SetWeatherServerName(string name, int index)
        {
            return await WeatherForecastService.SetWeatherServerName(name, index)
                .ConfigureAwait(false);
        }

        public IWeatherForecastService WeatherForecastService { get; }
    }
}