using Common.Data;
using System;
using System.Threading.Tasks;

namespace Server.Server
{
    public interface IClientRequestHandler
    {
        Task<WeatherForecast[]> GetForecastAsync(DateTime startDate);
    }
}