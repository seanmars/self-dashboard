using DashboardCore.Extensions;
using FastEndpoints;

namespace DashboardCore.Widgets.Calendar;

public class Endpoint : HtmlEndpointWithoutRequest<EmptyResponse>
{
    private readonly string _template;

    public Endpoint()
    {
        _template = File.ReadAllText("templates/widgets/calendar.hbs");
    }
    
    public override void Configure()
    {
        Get("/api/calendar");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Task.CompletedTask;

        var html = _template;

        await SendHtmlAsync(html, cancellation: ct);
    }
}