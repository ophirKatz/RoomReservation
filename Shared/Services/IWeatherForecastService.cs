using Shared.Data;
using System;
using System.Threading.Tasks;

namespace Shared.Services
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecast[]> GetForecastAsync(DateTime startDate);
    }
}