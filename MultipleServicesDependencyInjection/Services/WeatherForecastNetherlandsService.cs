using MultipleServicesDependencyInjection.Constants;
using MultipleServicesDependencyInjection.Models;

namespace MultipleServicesDependencyInjection.Services
{
    public class WeatherForecastNetherlandsService : IWeatherForecastService
    {
        public static readonly string[] Cities = new[]
        {
           "Amsterdam", "Utrecht", "Rotterdam"
        };
        public IEnumerable<WeatherForecastModel> GetWeatherForecasts()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecastModel
            {
                City = Cities[Random.Shared.Next(Cities.Length)],
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = WeatherForecastConstants.Summaries[Random.Shared.Next(WeatherForecastConstants.Summaries.Length)]
            })
            .ToArray();
        }
    }
}
