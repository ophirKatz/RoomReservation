using Common.Data;
using System.Threading.Tasks;

namespace Common.Communication
{
    public interface IWeatherClient
    {
        Task ReceiveWeatherForecast(WeatherForecast[] weatherForcasts);
        Task ReceiveWeatherServerName(string oldName, string newName);
    }
}