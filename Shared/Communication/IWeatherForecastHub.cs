using System;
using System.Threading.Tasks;

namespace Common.Communication
{
    public interface IWeatherForecastHub
    {
        Task GetForecastAsync(DateTime startDate);
    }
}