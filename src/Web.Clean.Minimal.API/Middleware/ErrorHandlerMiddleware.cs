using FluentValidation;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace Web.Clean.Minimal.API.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                HttpResponse response = context.Response;
                response.ContentType = MediaTypeNames.Application.Json;

                response.StatusCode = error switch
                {
                    ApplicationException => (int)HttpStatusCode.UnprocessableEntity,
                    KeyNotFoundException => (int)HttpStatusCode.NotFound,
                    ValidationException => (int)HttpStatusCode.BadRequest,
                    _ => (int)HttpStatusCode.InternalServerError,
                };

                _logger.LogError(error.Message);
                await response.WriteAsync(JsonSerializer.Serialize(error?.Message));
            }
        }
    }
}