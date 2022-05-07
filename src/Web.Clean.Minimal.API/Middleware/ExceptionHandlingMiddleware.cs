using FluentValidation;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace Web.Clean.Minimal.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                HttpResponse response = context.Response;
                response.ContentType = MediaTypeNames.Application.Json;

                response.StatusCode = exception switch
                {
                    ApplicationException => (int)HttpStatusCode.UnprocessableEntity,
                    KeyNotFoundException => (int)HttpStatusCode.NotFound,
                    ValidationException => (int)HttpStatusCode.BadRequest,
                    _ => (int)HttpStatusCode.InternalServerError,
                };

                _logger.LogError(exception, exception.Message);
                await response.WriteAsync(JsonSerializer.Serialize(exception?.Message));
            }
        }
    }
}