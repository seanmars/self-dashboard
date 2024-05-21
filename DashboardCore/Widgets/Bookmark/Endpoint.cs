using DashboardCore.Extensions;
using FastEndpoints;

namespace DashboardCore.Bookmark;

public class Endpoint : HtmlEndpointWithoutRequest<EmptyResponse>
{
    private readonly string _template;

    public Endpoint()
    {
        _template = File.ReadAllText("assets/templates/bookmark.liquid");
    }

    public override void Configure()
    {
        Get("/api/bookmark");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Task.CompletedTask;

        var html = _template;

        await SendHtmlAsync(html, cancellation: ct);
    }
}