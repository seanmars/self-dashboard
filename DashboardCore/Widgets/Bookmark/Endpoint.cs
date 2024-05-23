using DashboardCore.Extensions;
using DashboardCore.Helper;
using FastEndpoints;

namespace DashboardCore.Widgets.Bookmark;

public class Endpoint : HtmlEndpointWithoutRequest<EmptyResponse>
{
    private readonly ILogger<Endpoint> _logger;
    private readonly Feeder _feeder;
    private readonly TemplateProvider _template;

    public Endpoint(ILogger<Endpoint> logger, Feeder feeder, TemplateProvider templateProvider)
    {
        _logger = logger;
        _feeder = feeder;
        _template = templateProvider;
    }

    public override void Configure()
    {
        Get("/api/bookmark");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var bookmarks = _feeder.GetData();
        if (bookmarks is null)
        {
            await SendHtmlAsync(_template.Render("error",
                new
                {
                    Message = "Failed to get bookmarks"
                }), cancellation: ct);
            return;
        }

        await SendHtmlAsync(_template.Render("bookmark",
            new
            {
                Title = "Bookmark",
                Content = "Bookmark content"
            }), cancellation: ct);
    }
}