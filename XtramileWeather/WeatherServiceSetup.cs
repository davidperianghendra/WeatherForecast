using Microsoft.Extensions.DependencyInjection;
using XtramileWeather.Core.Services.Weather;
using XtramileWeather.Services.Weather;

namespace XtramileWeather.App
{
    public static class WeatherServiceSetup
    {
        public static IServiceCollection AddWeatherServices(this IServiceCollection services)
        {
            services.AddScoped<IOpenWeatherService, OpenWeatherService>();

            return services;
        }
    }
}
