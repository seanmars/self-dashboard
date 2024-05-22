using HandlebarsDotNet;

namespace DashboardCore.Helper;

public class TemplateProvider
{
    private readonly IHandlebars _handlebars;

    public TemplateProvider()
    {
        _handlebars = Handlebars.Create();

        Init();
    }

    private void Init()
    {
        _handlebars.RegisterTemplate("layout", File.ReadAllText("templates/layout.hbs"));
    }

    public string GetTemplate(string name)
    {
        return File.ReadAllText($"templates/widgets/{name}.hbs");
    }

    public string Render(string template, object data)
    {
        var content = GetTemplate(template);
        return _handlebars.Compile(content)(data);
    }
}