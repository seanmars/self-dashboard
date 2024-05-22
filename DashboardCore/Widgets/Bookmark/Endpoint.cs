using DashboardCore.Extensions;
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
        
        _template = File.ReadAllText("assets/templates/bookmark.liquid");
    }

    public override void Configure()
    {
        Get("/api/bookmark");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        _logger.LogInformation("Bookmark endpoint called");

        await Task.CompletedTask;

        var html = _template;

        await SendResultAsync(Results.Ok(_feeder.GetBookmarks()));
        // await SendHtmlAsync(html, cancellation: ct);
    }
}