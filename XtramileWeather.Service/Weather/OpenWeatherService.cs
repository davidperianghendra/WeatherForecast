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

namespace XtramileWeather.Services.Weather
{
    public class OpenWeatherService : IOpenWeatherService
    {
        private readonly WeatherConfigDto _weatherConfigDto;
        private const string OpenWeatherUrl = @"https://api.openweathermap.org/data/2.5/weather";
        private readonly ILogger<OpenWeatherService> _logger;

        public OpenWeatherService(
            WeatherConfigDto configDto,
            ILogger<OpenWeatherService> logger)
        {
            _weatherConfigDto = configDto;
            _logger = logger;
        }

        public async Task<Result<WeatherForecastResponse>> GetWeather(
            string country, 
            string city)
        {
            try
            {
                var request = WebRequest.Create($"{OpenWeatherUrl}?q={city},{country}&appid={_weatherConfigDto.ApiKey}");
                using (var webResponse = request.GetResponse())
                using (var webStream = webResponse.GetResponseStream())
                using (var webStreamReader = new StreamReader(webStream))
                {
                    string weatherResponse = await webStreamReader.ReadToEndAsync();

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
                        TemperatureC = KelvinTemperatureConverter.ConvertToCelcius(openWeatherResult.Main.Temp),
                        TemperatureF = KelvinTemperatureConverter.ConvertToFahrenheit(openWeatherResult.Main.Temp),
                    };
                    return Result<WeatherForecastResponse>.SuccessResult(result);
                }
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
