namespace Common.Data.EventArgs
{
    public class WeatherForecastEventArgs : System.EventArgs
    {
        public WeatherForecastEventArgs(WeatherForecast[] forecasts)
        {
            Forecasts = forecasts;
        }

        public WeatherForecast[] Forecasts { get; set; }
    }
}