using Common.Data;
using System.Threading.Tasks;

namespace Common.Communication
{
    public interface IWeatherClient
    {
        Task ReceiveWeatherForecast(WeatherForecast[] weatherForcasts);
    }
}