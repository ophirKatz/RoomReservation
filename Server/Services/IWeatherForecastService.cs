using Common.Data;
using System;
using System.Threading.Tasks;

namespace Server.Services
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecast[]> GetForecastAsync(DateTime startDate);
    }
}