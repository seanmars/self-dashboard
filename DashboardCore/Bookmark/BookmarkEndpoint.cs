using DashboardCore.Extensions;
using FastEndpoints;

namespace DashboardCore.Bookmark;

public class BookmarkEndpoint : HtmlEndpointWithoutRequest<EmptyResponse>
{
    public override void Configure()
    {
        Get("/bookmarks");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Task.CompletedTask;

        var html = "<html><body><h1>Bookmarks</h1></body></html>";

        await SendHtmlAsync(html, cancellation: ct);
    }
}