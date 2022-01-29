using Microsoft.Extensions.DependencyInjection;
using XtramileWeather.Core.Services;
using XtramileWeather.Core.Services.Weather;
using XtramileWeather.Service;
using XtramileWeather.Services.Weather;

namespace XtramileWeather.App
{
    public static class WeatherServiceSetup
    {
        public static IServiceCollection AddWeatherServices(this IServiceCollection services)
        {
            services.AddScoped<IWebClientService, WebClientService>();
            services.AddScoped<IOpenWeatherService, OpenWeatherService>();

            return services;
        }
    }
}
