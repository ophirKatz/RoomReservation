using System;
using System.Threading.Tasks;

namespace BlazorPOC.Client
{
    public interface IServerProxy
    {
        Task GetForecastAsync(DateTime startDate);
        Task SetWeatherServerName(string name, int index);
    }
}