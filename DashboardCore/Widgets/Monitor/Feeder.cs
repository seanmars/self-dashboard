namespace DashboardCore.Widgets.Monitor;

public class Feeder
{
    private readonly ILogger<Feeder> _logger;
    private readonly SettingManager _settingManager;

    public Feeder(ILogger<Feeder> logger, SettingManager settingManager)
    {
        _logger = logger;
        _settingManager = settingManager;
    }

    public List<Model>? GetData()
    {
        try
        {
            return _settingManager.Get<List<Model>>("widgets:monitors");
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to get monitors");
            return default;
        }
    }
}