using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XtramileWeather.App.Controllers;
using XtramileWeather.Core.Dto.Weather;
using XtramileWeather.Core.Services;
using XtramileWeather.Core.Services.Weather;
using XtramileWeather.Services.Weather;

namespace XtramileWeather.Test
{
    [TestClass]
    public class WeatherForecastControllerTest
    {
        private WeatherConfigDto _weatherConfig;
        private IOpenWeatherService _openWeatherService;
        private Mock<ILogger<WeatherForecastController>> _loggerMock;
        private Mock<ILogger<OpenWeatherService>> _loggerServiceMock;
        private WeatherForecastController _weatherForecastController;
        private Mock<IWebClientService> _webClientServiceMock;

        [TestInitialize]
        public void TestInitialize()
        {
            this._weatherConfig = new WeatherConfigDto()
            {
                ApiKey = "helloworld",
                Countries = new List<CountryDto> { new CountryDto { Alpha2Code = "ID", EnglishShortName = "Indonesia" } },
                Cities = new List<CityDto> { new CityDto { Country = "ID", Name = "Jakarta" } },
            };
            this._loggerMock = new Mock<ILogger<WeatherForecastController>>();
            this._loggerServiceMock = new Mock<ILogger<OpenWeatherService>>();
            this._webClientServiceMock = new Mock<IWebClientService>();
            this._openWeatherService = new OpenWeatherService(
                                        this._weatherConfig,
                                        this._loggerServiceMock.Object,
                                        this._webClientServiceMock.Object);
            
            this._weatherForecastController = new WeatherForecastController(
                                                    this._weatherConfig,
                                                    this._openWeatherService,
                                                    this._loggerMock.Object);
        }

        [TestMethod]
        public async Task WeatherForecast_GetWeather_ReturnSuccessResult()
        {
            var openWeatherResponseBase64 = "eyJjb29yZCI6eyJsb24iOjEwNi44NDUxLCJsYXQiOi02LjIxNDZ9LCJ3ZWF0aGVyIjpbeyJpZCI6NzIxLCJtYWluIjoiSGF6ZSIsImRlc2NyaXB0aW9uIjoiaGF6ZSIsImljb24iOiI1MGQifV0sImJhc2UiOiJzdGF0aW9ucyIsIm1haW4iOnsidGVtcCI6MzA0LjcyLCJmZWVsc19saWtlIjozMTAuMSwidGVtcF9taW4iOjMwMS45OCwidGVtcF9tYXgiOjMwNy42NCwicHJlc3N1cmUiOjEwMTAsImh1bWlkaXR5Ijo2M30sInZpc2liaWxpdHkiOjUwMDAsIndpbmQiOnsic3BlZWQiOjEuNTQsImRlZyI6MjcwfSwiY2xvdWRzIjp7ImFsbCI6NDB9LCJkdCI6MTY0MzQyOTk1Mywic3lzIjp7InR5cGUiOjEsImlkIjo5MzgzLCJjb3VudHJ5IjoiSUQiLCJzdW5yaXNlIjoxNjQzNDEwNDM2LCJzdW5zZXQiOjE2NDM0NTUwMzJ9LCJ0aW1lem9uZSI6MjUyMDAsImlkIjoxNjQyOTExLCJuYW1lIjoiSmFrYXJ0YSIsImNvZCI6MjAwfQ==";
            var responseBytes = Convert.FromBase64String(openWeatherResponseBase64);
            var openWeatherResponse = System.Text.Encoding.UTF8.GetString(responseBytes);

            this._webClientServiceMock.Setup(
                x => x.Get(It.IsAny<Uri>())
            ).ReturnsAsync(openWeatherResponse);

            var result = await this._weatherForecastController.Get("ID", "Jakarta");

            Assert.IsNotNull(result);
            Assert.IsTrue(result is OkObjectResult);
        }

        [TestMethod]
        public async Task WeatherForecast_GetWeather_ReturnFailedResult()
        {
            this._webClientServiceMock.Setup(
                x => x.Get(It.IsAny<Uri>())
            ).ThrowsAsync(new Exception("Unable connect to remote host"));

            var result = await this._weatherForecastController.Get("ID", "Jakarta");

            Assert.IsNotNull(result);
            Assert.IsTrue(result is NoContentResult);
        }
    }
}
