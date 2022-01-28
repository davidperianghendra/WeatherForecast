using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using XtramileWeather.Core.Services.Response;
using XtramileWeather.Core.Services.Weather;

namespace XtramileWeather.Test
{
    [TestClass]
    public class OpenWeatherServiceTest
    {
        private Mock<IOpenWeatherService> _openWeatherService;

        [TestInitialize]
        public void TestInitialize()
        {
            this._openWeatherService = new Mock<IOpenWeatherService>();
        }

        [TestMethod]
        public async Task OpenWeatherService_GetWeather_ReturnSuccessResult()
        {
            this._openWeatherService.Setup(
                x => x.GetWeather(It.IsAny<string>(), It.IsAny<string>())
            ).ReturnsAsync(Result<WeatherForecastResponse>.SuccessResult(new WeatherForecastResponse()));

            var result = await this._openWeatherService.Object.GetWeather("ID", "Jakarta");

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
        }

        [TestMethod]
        public async Task OpenWeatherService_GetWeather_ReturnFailedResult()
        {
            var errorMessage = "Error";
            this._openWeatherService.Setup(
                x => x.GetWeather(It.IsAny<string>(), It.IsAny<string>())
            ).ReturnsAsync(Result<WeatherForecastResponse>.FailedResult(errorMessage));

            var result = await this._openWeatherService.Object.GetWeather("ID", "Jakarta");

            Assert.IsNotNull(result);
            Assert.IsFalse(result.Success);
            Assert.AreEqual(result.Error, errorMessage);
        }
    }
}
