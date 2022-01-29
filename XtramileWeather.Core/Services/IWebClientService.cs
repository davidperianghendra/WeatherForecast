using System;
using System.Threading.Tasks;

namespace XtramileWeather.Core.Services
{
    public interface IWebClientService
    {
        Task<string> Get(Uri httpUri);
    }
}
