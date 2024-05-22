using DashboardCore.Widgets;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsole()
    .SetMinimumLevel(builder.Environment.IsDevelopment() ? LogLevel.Debug : LogLevel.Warning);

builder.Configuration.AddEnvironmentVariables();

// Add services to the container.
builder.Services.AddWidgets();
builder.Services.AddFastEndpoints();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseFastEndpoints();

app.Run();