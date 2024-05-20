using FastEndpoints;

namespace DashboardCore.Extensions;

public class HtmlEndpointWithoutRequest<TResponse> : EndpointWithoutRequest<TResponse>
{
    protected Task SendHtmlAsync(string html, CancellationToken cancellation) =>
        SendStringAsync(html, contentType: "text/html charset=utf-8", cancellation: cancellation);
}