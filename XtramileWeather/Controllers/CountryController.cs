using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using XtramileWeather.Core.Dto.Weather;

namespace XtramileWeather.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ILogger<CountryController> _logger;
        private readonly WeatherConfigDto _weatherConfigDto;

        public CountryController(
            WeatherConfigDto weatherConfig,
            ILogger<CountryController> logger)
        {
            _weatherConfigDto = weatherConfig;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_weatherConfigDto.Countries);
        }
    }
}
