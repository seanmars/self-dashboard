namespace DashboardCore.Widgets.Weather;

public static class ServiceExtension
{
    public static IServiceCollection AddWeatherWidget(this IServiceCollection services)
    {
        services.AddScoped<Feeder>();

        return services;
    }
}