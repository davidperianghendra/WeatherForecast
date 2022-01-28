using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using XtramileWeather.Core.Dto.Weather;
using XtramileWeather.Core.Services.Weather;

namespace XtramileWeather.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherConfigDto _weatherConfigDto;
        private readonly IOpenWeatherService _openWeatherService;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(
            WeatherConfigDto weatherConfig,
            IOpenWeatherService openWeatherService,
            ILogger<WeatherForecastController> logger)
        {
            _openWeatherService = openWeatherService;
            _weatherConfigDto = weatherConfig;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string country, string city)
        {
            if (!_weatherConfigDto.Cities.Any(x => x.Country == country && x.Name == city))
                return NotFound();

            var weatherResult = await _openWeatherService.GetWeather(country, city);
            if (!weatherResult.Success)
                return NoContent();

            return Ok(weatherResult.Item);
        }
    }
}
