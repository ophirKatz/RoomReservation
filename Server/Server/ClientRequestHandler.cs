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
            return await WeatherForecastService.GetForecastAsync(startDate);
        }

        public IWeatherForecastService WeatherForecastService { get; }
    }
}