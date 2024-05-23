using System.Collections.Concurrent;
using HandlebarsDotNet;

namespace DashboardCore.Helper;

public class TemplateProvider
{
    private readonly IHandlebars _handlebars;

    [ThreadStatic]
    private static ConcurrentDictionary<string, string>? _templates;

    private static ConcurrentDictionary<string, string> Templates => _templates ??= new();

    public TemplateProvider()
    {
        _handlebars = Handlebars.Create();

        Init();
    }

    private string GetHandlebar(string name, string? subFolder = null)
    {
        if (Templates.TryGetValue(name, out var template))
        {
            return template;
        }

        var path = subFolder is null
            ? $"templates/{name}.hbs"
            : $"templates/{subFolder}/{name}.hbs";

        var content = File.ReadAllText(path);

        Templates.TryAdd(name, content);

        return content;
    }

    private void Init()
    {
        _handlebars.RegisterTemplate("layout", GetHandlebar("layout"));
    }

    public string Render(string template, object data)
    {
        var content = GetHandlebar(template, "widgets");
        return _handlebars.Compile(content)(data);
    }
}