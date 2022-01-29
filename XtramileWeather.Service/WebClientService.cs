using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using XtramileWeather.Core.Services;

namespace XtramileWeather.Service
{
    public class WebClientService : IWebClientService
    {
        public async Task<string> Get(Uri httpUri)
        {
            var request = WebRequest.Create(httpUri);
            using (var webResponse = request.GetResponse())
            using (var webStream = webResponse.GetResponseStream())
            using (var webStreamReader = new StreamReader(webStream))
            {
                string weatherResponse = await webStreamReader.ReadToEndAsync();

                return weatherResponse;
            }
        }
    }
}
