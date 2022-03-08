using FluentValidation;

namespace Application.WeatherForecasts.Queries.GetWeatherForecast
{
    public class GetWeatherForecastQueryValidator : AbstractValidator<GetWeatherForecastQuery>
    {
        public GetWeatherForecastQueryValidator()
        {
            RuleFor(prop => prop.City).NotEmpty();
        }
    }
}