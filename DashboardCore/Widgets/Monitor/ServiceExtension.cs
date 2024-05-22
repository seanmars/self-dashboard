namespace DashboardCore.Widgets.Monitor;

public static class ServiceExtension
{
    public static IServiceCollection AddMonitorWidget(this IServiceCollection services)
    {
        services.AddScoped<Feeder>();

        return services;
    }
}