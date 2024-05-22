using System.Text.Json;
using DashboardCore.Extensions;
using FastEndpoints;

namespace DashboardCore.Widgets.Monitor;

public class Endpoint : HtmlEndpointWithoutRequest<EmptyResponse>
{
    private readonly ILogger<Endpoint> _logger;
    private readonly Feeder _feeder;
    private readonly string _template;

    public Endpoint(ILogger<Endpoint> logger, Feeder feeder)
    {
        _logger = logger;
        _feeder = feeder;
        _template = File.ReadAllText("assets/templates/monitor.liquid");
    }

    public override void Configure()
    {
        Get("/api/monitor");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Task.CompletedTask;

        var html = _template;

        var monitors = _feeder.GetMonitors();
        _logger.LogDebug("{Json}", JsonSerializer.Serialize(monitors));

        await SendHtmlAsync(html, cancellation: ct);
    }
}