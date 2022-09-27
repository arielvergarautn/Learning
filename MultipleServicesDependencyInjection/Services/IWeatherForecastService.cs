using MultipleServicesDependencyInjection.Models;

namespace MultipleServicesDependencyInjection.Services
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecastModel> GetWeatherForecasts();
    }
}
