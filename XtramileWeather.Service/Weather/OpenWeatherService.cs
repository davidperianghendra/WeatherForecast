using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using XtramileWeather.Core.Dto.Weather;
using XtramileWeather.Core.Services.Response;
using XtramileWeather.Core.Service.Response;
using XtramileWeather.Core.Services.Weather;
using XtramileWeather.Service.Utility;
using XtramileWeather.Core.Services;

namespace XtramileWeather.Services.Weather
{
    public class OpenWeatherService : IOpenWeatherService
    {
        private readonly WeatherConfigDto _weatherConfigDto;
        private const string OpenWeatherUrl = @"https://api.openweathermap.org/data/2.5/weather";
        private readonly ILogger<OpenWeatherService> _logger;
        private readonly IWebClientService _webService;

        public OpenWeatherService(
            WeatherConfigDto configDto,
            ILogger<OpenWeatherService> logger,
            IWebClientService webService)
        {
            _weatherConfigDto = configDto;
            _logger = logger;
            _webService = webService;
        }

        public async Task<Result<WeatherForecastResponse>> GetWeather(
            string country, 
            string city)
        {
            try
            {
                var getWeatherUri = new Uri($"{OpenWeatherUrl}?q={city},{country}&appid={_weatherConfigDto.ApiKey}");
                var weatherResponse = await this._webService.Get(getWeatherUri);
                var openWeatherResult = JsonSerializer.Deserialize<WeatherForecastResultDto>(weatherResponse);

                DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                dtDateTime = dtDateTime.AddSeconds(openWeatherResult.Dt).ToLocalTime();

                var result = new WeatherForecastResponse()
                {
                    Location = new WeatherLocationResponse()
                    {
                        Latitude = openWeatherResult.Coordinate.Latitude,
                        Longitude = openWeatherResult.Coordinate.Longitude
                    },
                    Wind = openWeatherResult.Wind,
                    Time = $"{dtDateTime.TimeOfDay:hh\\:mm\\:ss}",
                    Visibility = openWeatherResult.Visibility,
                    Sky = openWeatherResult.Weather,
                    Humidity = openWeatherResult.Main.Humidity,
                    Pressure = openWeatherResult.Main.Pressure,
                    Temperature = openWeatherResult.Main.Temp,
                    TemperatureC = KelvinTemperatureConverter.ConvertToCelcius(openWeatherResult.Main.Temp),
                    TemperatureF = KelvinTemperatureConverter.ConvertToFahrenheit(openWeatherResult.Main.Temp),
                };
                return Result<WeatherForecastResponse>.SuccessResult(result);
            }
            catch (Exception ex)
            {
                var errorMessage = "Error when retrieving weather";
                _logger.LogError(ex, errorMessage);
                return Result<WeatherForecastResponse>.FailedResult(errorMessage);
            }
        }
    }
}
