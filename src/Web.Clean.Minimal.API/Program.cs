using Application;
using Application.WeatherForecasts.Queries.GetWeatherForecast;
using MediatR;
using Web.Clean.Minimal.API.Middleware;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/v1/weatherforecast/city/{city}", (IMediator mediator, string city, CancellationToken cancellationToken) =>
{
    return mediator.Send(new GetWeatherForecastQuery(city), cancellationToken);
})
.WithName("GetWeatherForecast")
.WithTags("WeatherForecast");

app.Run();