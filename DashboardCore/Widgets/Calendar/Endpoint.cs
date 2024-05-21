using DashboardCore.Extensions;
using FastEndpoints;

namespace DashboardCore.Calendar;

public class Endpoint : HtmlEndpointWithoutRequest<EmptyResponse>
{
    private readonly string _template;

    public Endpoint()
    {
        _template = File.ReadAllText("assets/templates/calendar.liquid");
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