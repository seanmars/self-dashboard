using DashboardCore.Extensions;
using DashboardCore.Helper;
using FastEndpoints;

namespace DashboardCore.Widgets.Bookmark;

public class Endpoint : HtmlEndpointWithoutRequest<EmptyResponse>
{
    private readonly ILogger<Endpoint> _logger;
    private readonly Feeder _feeder;
    private readonly string _template;

    public Endpoint(ILogger<Endpoint> logger, Feeder feeder)
    {
        _logger = logger;
        _feeder = feeder;

        _template = File.ReadAllText("templates/widgets/bookmark.hbs");
    }

    public override void Configure()
    {
        Get("/api/bookmark");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        _logger.LogInformation("Bookmark endpoint called");

        var tmp = new TemplateProvider();
        
        var html = tmp.Render("bookmark", new { Title = "Bookmark", Content = "Bookmark content" });

        await SendHtmlAsync(html, cancellation: ct);
    }
}