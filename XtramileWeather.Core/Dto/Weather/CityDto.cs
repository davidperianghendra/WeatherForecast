using System.Text.Json.Serialization;

namespace XtramileWeather.Core.Dto.Weather
{
    public class CityDto
    {
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("lat")]
        public string Longitute { get; set; }
        [JsonPropertyName("lng")]
        public string Latitude { get; set; }
    }
}
