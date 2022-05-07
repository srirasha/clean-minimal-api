using Application;
using Application.WeatherForecasts.Queries.GetWeatherForecast;
using MediatR;
using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;
using System.Reflection;
using Web.Clean.Minimal.API.Middleware;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration().Enrich.FromLogContext()
                                      .Enrich.WithExceptionDetails()
                                      .WriteTo.Console()
                                      .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(builder.Configuration["Elastic:Uri"]))
                                      {
                                          AutoRegisterTemplate = true,
                                          IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name.ToLower()}-{DateTime.UtcNow:yyyy}"
                                      })
                                      .CreateLogger();
builder.Host.UseSerilog();
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