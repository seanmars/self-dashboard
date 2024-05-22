using System.Text.Json;
using System.Text.Json.Serialization;

namespace DashboardCore;

public class SettingManager
{
    private readonly ILogger<SettingManager> _logger;
    private readonly FileSystemWatcher _watcher;

    private readonly JsonSerializerOptions _jsonOptions;
    private JsonDocument? _jsonDoc;

    public SettingManager(ILogger<SettingManager> logger)
    {
        _logger = logger;

        _watcher = new();
        _watcher.Path = "./";
        _watcher.IncludeSubdirectories = false;
        _watcher.Filter = "settings.json";
        _watcher.NotifyFilter = NotifyFilters.LastWrite;
        _watcher.Changed += OnChanged;
        _watcher.EnableRaisingEvents = true;

        _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = false,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
            AllowTrailingCommas = true,
        };

        LoadSettings();
    }

    private void LoadSettings()
    {
        try
        {
            _jsonDoc = JsonDocument.Parse(File.ReadAllText("settings.json"));
            _jsonDoc.RootElement.TryGetProperty("widgets", out var widgets);
        }
        catch (JsonException ex)
        {
            _logger.LogError(ex, "Failed to parse settings file");
        }
    }

    private void OnChanged(object sender, FileSystemEventArgs e)
    {
        _logger.LogInformation("Settings file changed");
        LoadSettings();
    }

    public T? Get<T>(string key)
    {
        if (_jsonDoc is null)
        {
            return default;
        }

        var jsonElement = _jsonDoc.RootElement;

        foreach (var part in key.Split(':'))
        {
            if (!jsonElement.TryGetProperty(part, out var property))
            {
                return default;
            }

            jsonElement = property;
        }

        return jsonElement.Deserialize<T>(_jsonOptions);
    }
}