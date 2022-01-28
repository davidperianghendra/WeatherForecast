using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using XtramileWeather.Core.Dto.Weather;

namespace XtramileWeather.App
{
    public static class WeatherConfigSetup
    {
        private const string CountryResourceName = "XtramileWeather.App.countries.json";
        private const string CityResourceName = "XtramileWeather.App.cities.json";

        public static IServiceCollection AddWeatherConfig(this IServiceCollection services, string openWeatherApiKey)
        {
            var assembly = Assembly.GetExecutingAssembly();
            
            var config = new WeatherConfigDto();

            using (var countryStream = assembly.GetManifestResourceStream(CountryResourceName))
            using (var countryStreamReader = new StreamReader(countryStream))
            {
                var countryContentJson = countryStreamReader.ReadToEnd();
                var countries = JsonSerializer.Deserialize<IEnumerable<CountryDto>>(countryContentJson);
                config.Countries = countries.ToList();
            }

            using (var cityStream = assembly.GetManifestResourceStream(CityResourceName))
            using (var cityStreamReader = new StreamReader(cityStream))
            {
                var cityContentJson = cityStreamReader.ReadToEnd();
                var cities = JsonSerializer.Deserialize<IEnumerable<CityDto>>(cityContentJson);
                config.Cities = cities.ToList();
            }

            config.ApiKey = openWeatherApiKey;

            services.AddSingleton(config);
            return services;
        }
    }
}
