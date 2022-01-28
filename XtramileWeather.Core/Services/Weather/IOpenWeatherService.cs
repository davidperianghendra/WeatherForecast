using System.Threading.Tasks;
using XtramileWeather.Core.Services.Response;

namespace XtramileWeather.Core.Services.Weather
{
    public interface IOpenWeatherService
    {
        Task<Result<WeatherForecastResponse>> GetWeather(string country, string city);
    }
}
