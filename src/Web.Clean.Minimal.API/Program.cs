using Application;
using Application.WeatherForecasts.Queries.GetWeatherForecast;
using MediatR;
using Serilog;
using Web.Clean.Minimal.API.Extensions;
using Web.Clean.Minimal.API.Middleware;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.AddSerilog();
builder.AddSwagger();

builder.Services.AddApplication();

WebApplication app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.EnableSwagger();

app.MapGet("api/v1/weatherforecast/city/{city}", (IMediator mediator, string city, CancellationToken cancellationToken) =>
{
    return mediator.Send(new GetWeatherForecastQuery(city), cancellationToken);
})
.WithName("GetWeatherForecast")
.WithTags("WeatherForecast");

app.Run();