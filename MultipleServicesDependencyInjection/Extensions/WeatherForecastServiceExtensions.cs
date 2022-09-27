using MultipleServicesDependencyInjection.Services;

namespace MultipleServicesDependencyInjection.Extensions
{
    public static class WeatherForecastServiceExtensions
    {
        public static IServiceCollection AddWeatherForecastServices(this IServiceCollection services)
        {
            services.AddScoped<IWeatherForecastService, WeatherForecastNetherlandsService>();
            services.AddScoped<IWeatherForecastService, WeatherForecastArgentinaService>();

            return services;
        }
    }
}
