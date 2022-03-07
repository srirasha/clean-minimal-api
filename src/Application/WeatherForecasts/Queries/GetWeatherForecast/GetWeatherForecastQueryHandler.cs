using Domain;
using MediatR;

namespace Application.WeatherForecasts.Queries.GetWeatherForecast
{
    public class GetWeatherForecastQueryHandler : IRequestHandler<GetWeatherForecastQuery, IEnumerable<WeatherForecast>>
    {
        public async Task<IEnumerable<WeatherForecast>> Handle(GetWeatherForecastQuery request, CancellationToken cancellationToken)
        {
            string[] summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

            IEnumerable<WeatherForecast> forecast = Enumerable.Range(1, 5).Select(index =>
               new WeatherForecast
               (
                   DateTime.Now.AddDays(index),
                   Random.Shared.Next(-20, 55),
                   summaries[Random.Shared.Next(summaries.Length)]
               ));


            return await Task.FromResult(forecast);
        }
    }
}