namespace XtramileWeather.Service.Utility
{
    public static class KelvinTemperatureConverter
    {
        public static double ConvertToCelcius(double kelvinTemperature)
        {
            return kelvinTemperature - 273;
        }

        public static double ConvertToFahrenheit(double kelvinTemperature)
        {
            return (kelvinTemperature * 9 / 5 - 459.67);
        }
    }
}
