using DashboardCore.Extensions;
using DashboardCore.Helper;
using FastEndpoints;

namespace DashboardCore.Widgets.Calendar;

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
        Get("/api/calendar");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var today = _feeder.GetData();
        if (today is null)
        {
            await SendHtmlAsync(_template.Render("error",
                new
                {
                    Message = "Failed to get calendar"
                }), cancellation: ct);
            return;
        }

        await SendHtmlAsync(_template.Render("calendar",
            new
            {
                Title = "Calendar",
                Content = $"Today is {today.Value.year}-{today.Value.month}-{today.Value.day}"
            }), cancellation: ct);
    }
}