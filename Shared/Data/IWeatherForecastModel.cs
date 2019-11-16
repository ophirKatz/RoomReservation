using Common.Data.EventArgs;
using System;

namespace Common.Data
{
    public interface IWeatherForecastModel
    {
        event EventHandler<WeatherForecastEventArgs> WeatherForecastsChanged;
        WeatherForecast[] WeatherForecasts { get; set; }
    }
}