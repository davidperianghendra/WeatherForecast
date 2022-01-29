using System.Collections.Generic;
using System.Text.Json.Serialization;
using XtramileWeather.Core.Service.Response;

namespace XtramileWeather.Core.Services.Response
{
    public class WeatherLocationResponse
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class WeatherForecastResponse
    {
        public WeatherLocationResponse Location { get; set; }
        public string Time { get; set; }
        public WeatherResultWind Wind { get; set; }
        public int Visibility { get; set; }
        public List<WeatherResultWeather> Sky { get; set; }
        public double Temperature { get; set; }
        public double TemperatureC { get; set; }
        public double TemperatureF { get; set; }
        public string DewPoint { get; set; }
        public int Humidity { get; set; }
        public int Pressure { get; set; }
    }
}
