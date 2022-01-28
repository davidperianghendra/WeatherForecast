using System.Text.Json.Serialization;

namespace XtramileWeather.Core.Dto.Weather
{
    public class CountryDto
    {
        [JsonPropertyName("englishShortName")]
        public string EnglishShortName { get; set; }
        [JsonPropertyName("frenchShortName")]
        public string FrenshShortName { get; set; }
        [JsonPropertyName("alpha2Code")]
        public string Alpha2Code { get; set; }
        [JsonPropertyName("alpha3Code")]
        public string Alpha3Code { get; set; }
    }
}
