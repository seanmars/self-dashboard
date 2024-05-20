using DashboardCore.Extensions;
using FastEndpoints;

namespace DashboardCore.Stock;

public class StockEndpoint : HtmlEndpointWithoutRequest<EmptyResponse>
{
    private readonly string _template;

    public StockEndpoint()
    {
        _template = File.ReadAllText("assets/templates/stock.liquid");
    }

    public override void Configure()
    {
        Get("/api/stock");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Task.CompletedTask;

        var html = _template;

        await SendHtmlAsync(html, cancellation: ct);
    }
}