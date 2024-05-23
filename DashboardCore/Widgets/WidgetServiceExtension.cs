using DashboardCore.Helper;
using DashboardCore.Widgets.Bookmark;
using DashboardCore.Widgets.Calendar;
using DashboardCore.Widgets.Monitor;
using DashboardCore.Widgets.Stock;
using DashboardCore.Widgets.Weather;

namespace DashboardCore.Widgets;

public static class WidgetServiceExtension
{
    public static IServiceCollection AddWidgets(this IServiceCollection service)
    {
        return service
            .AddSingleton<SettingManager>()
            .AddSingleton<TemplateProvider>()
            .AddBookmarkWidget()
            .AddCalendarWidget()
            .AddMonitorWidget()
            .AddStockWidget()
            .AddWeatherWidget();
    }
}