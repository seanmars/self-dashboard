using DashboardCore.Widgets.Bookmark;
using DashboardCore.Widgets.Monitor;

namespace DashboardCore.Widgets;

public static class WidgetServiceExtension
{
    public static IServiceCollection AddWidgets(this IServiceCollection service)
    {
        return service
            .AddSingleton<SettingManager>()
            .AddMonitorWidget()
            .AddBookmarkWidget();
    }
}