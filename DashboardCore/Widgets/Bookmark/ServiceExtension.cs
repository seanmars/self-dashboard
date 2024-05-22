namespace DashboardCore.Widgets.Bookmark;

public static class ServiceExtension
{
    public static IServiceCollection AddBookmarkWidget(this IServiceCollection services)
    {
        services.AddScoped<Feeder>();

        return services;
    }
}