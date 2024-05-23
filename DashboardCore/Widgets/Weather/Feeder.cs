namespace DashboardCore.Widgets.Weather;

public class Feeder
{
    private const string Key = "widgets:weather";

    private readonly ILogger<Feeder> _logger;
    private readonly SettingManager _settingManager;

    public Feeder(ILogger<Feeder> logger, SettingManager settingManager)
    {
        _logger = logger;
        _settingManager = settingManager;
    }

    public void GetData()
    {
        try
        {
            var model = _settingManager.Get<Model>(Key);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to get weather");
            return;
        }
    }
}