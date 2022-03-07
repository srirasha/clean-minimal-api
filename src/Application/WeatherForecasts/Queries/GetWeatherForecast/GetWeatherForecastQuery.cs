using Domain;
using MediatR;

namespace Application.WeatherForecasts.Queries.GetWeatherForecast
{
    public class GetWeatherForecastQuery : IRequest<IEnumerable<WeatherForecast>>
    {
        public GetWeatherForecastQuery(string city)
        {
            City = city;
        }

        public string City { get; set; }
    }
}