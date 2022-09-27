using Microsoft.AspNetCore.Mvc;
using MultipleServicesDependencyInjection.Models;
using MultipleServicesDependencyInjection.Services;

namespace MultipleServicesDependencyInjection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IEnumerable<IWeatherForecastService> _weatherForecastServices;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IEnumerable<IWeatherForecastService> weatherForecastServices)
        {
            _logger = logger;
            _weatherForecastServices = weatherForecastServices;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecastModel> Get()
        {
            var result = new List<WeatherForecastModel>();
            
            foreach (var service in _weatherForecastServices)
            {
                var weatherForecasts = service.GetWeatherForecasts();

                result.AddRange(weatherForecasts);
            }

            return result;
        }
    }
}