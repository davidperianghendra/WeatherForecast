using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using XtramileWeather.Core.Dto.Weather;

namespace XtramileWeather.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : ControllerBase
    {
        private readonly ILogger<CityController> _logger;
        private readonly WeatherConfigDto _weatherConfigDto;

        public CityController(
            WeatherConfigDto weatherConfig,
            ILogger<CityController> logger)
        {
            _weatherConfigDto = weatherConfig;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get(string country)
        {
            if (!_weatherConfigDto.Cities.Any(x => x.Country == country))
                return NotFound();

            return Ok(_weatherConfigDto.Cities.Where(x => x.Country == country));
        }
    }
}
