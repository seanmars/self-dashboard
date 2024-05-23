namespace DashboardCore.Widgets.Calendar;

public class Feeder
{
    private const string Key = "widgets:calendar";

    private readonly ILogger<Feeder> _logger;
    private readonly SettingManager _settingManager;

    public Feeder(ILogger<Feeder> logger, SettingManager settingManager)
    {
        _logger = logger;
        _settingManager = settingManager;
    }

    public (int year, int month, int day)? GetData()
    {
        try
        {
            var model = _settingManager.Get<Model>(Key);
            if (model is null)
            {
                return default;
            }

            var date = DateTimeOffset.Now.ToOffset(TimeSpan.FromHours(model.Offset));
            return (date.Year, date.Month, date.Day);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to get calendar");
            return default;
        }
    }
}