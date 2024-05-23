namespace DashboardCore.Widgets.Calendar;

public static class ServiceExtension
{
    public static IServiceCollection AddCalendarWidget(this IServiceCollection services)
    {
        services.AddScoped<Feeder>();

        return services;
    }
}