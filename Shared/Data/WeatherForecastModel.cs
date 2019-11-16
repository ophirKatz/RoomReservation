using Common.Data.EventArgs;
using System;

namespace Common.Data
{
    public class WeatherForecastModel : IWeatherForecastModel
    {
        public event EventHandler<WeatherForecastEventArgs> WeatherForecastsChanged;

        public WeatherForecast[] WeatherForecasts
        {
            get => _weatherForecasts;
            set
            {
                _weatherForecasts = value;
                WeatherForecastsChanged?.Invoke(this, new WeatherForecastEventArgs(_weatherForecasts));
            }
        }

        private WeatherForecast[] _weatherForecasts;
    }
}