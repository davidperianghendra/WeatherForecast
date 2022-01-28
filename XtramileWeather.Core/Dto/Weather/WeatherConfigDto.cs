using System.Collections.Generic;

namespace XtramileWeather.Core.Dto.Weather
{
    public class WeatherConfigDto
    {
        public List<CountryDto> Countries { get; set; }
        public List<CityDto> Cities { get; set; }
        public string ApiKey { get; set; }
    }
}
