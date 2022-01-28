using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace XtramileWeather.Core.Service.Response
{
    public class WeatherResultCoordinate
    {
        [JsonPropertyName("lon")]
        public double Longitude { get; set; }
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }
    }

    public class WeatherResultWeather
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("main")]
        public string Main { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
    }

    public class WeatherResultMain
    {
        [JsonPropertyName("temp")]
        public double Temp { get; set; }
        [JsonPropertyName("feels_like")]
        public double FeelsLike { get; set; }
        [JsonPropertyName("temp_min")]
        public double TempMin { get; set; }
        [JsonPropertyName("temp_max")]
        public double TempMax { get; set; }
        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }
        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
    }

    public class WeatherResultWind
    {
        [JsonPropertyName("speed")]
        public double Speed { get; set; }
        [JsonPropertyName("deg")]
        public int Deg { get; set; }
    }

    public class WeatherResultRainDto
    {
        [JsonPropertyName("1h")]
        public double OneHour { get; set; }
    }

    public class WeatherResultCloudsDto
    {
        [JsonPropertyName("all")]
        public int All { get; set; }
    }

    public class WeatherResultSysDto
    {
        [JsonPropertyName("type")]
        public int Type { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("message")]
        public double Message { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("sunrise")]
        public int Sunrise { get; set; }
        [JsonPropertyName("sunset")]
        public int Sunset { get; set; }
    }

    public class WeatherForecastResultDto
    {
        [JsonPropertyName("coord")]
        public WeatherResultCoordinate Coordinate { get; set; }
        [JsonPropertyName("weather")]
        public List<WeatherResultWeather> Weather { get; set; }
        [JsonPropertyName("base")]
        public string Base { get; set; }
        [JsonPropertyName("main")]
        public WeatherResultMain Main { get; set; }
        [JsonPropertyName("visibility")]
        public int Visibility { get; set; }
        [JsonPropertyName("wind")]
        public WeatherResultWind Wind { get; set; }
        [JsonPropertyName("clouds")]
        public WeatherResultCloudsDto Clouds { get; set; }
        [JsonPropertyName("dt")]
        public int Dt { get; set; }
        [JsonPropertyName("sys")]
        public WeatherResultSysDto Sys { get; set; }
        [JsonPropertyName("timezone")]
        public int Timezone { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("cod")]
        public int Cod { get; set; }
    }
}
