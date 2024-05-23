namespace DashboardCore.Widgets.Stock;

public static class ServiceExtension
{
    public static IServiceCollection AddStockWidget(this IServiceCollection services)
    {
        services.AddScoped<Feeder>();

        return services;
    }
}