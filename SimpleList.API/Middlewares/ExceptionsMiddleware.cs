using SimpleList.API.Models.Errors;
using SimpleList.Application.Exceptions;
using SimpleList.Application.Utils;
using System.Net;

namespace SimpleList.API.Middlewares
{
    public class ExceptionsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionsMiddleware> _logger;
        private readonly IHostEnvironment _hostEnvironment;

        public ExceptionsMiddleware(
            RequestDelegate next,
            ILogger<ExceptionsMiddleware> logger,
            IHostEnvironment hostEnvironment)
        {
            _next = next;
            _logger = logger;
            _hostEnvironment = hostEnvironment;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                context.Response.ContentType = "application/json";
                int statusCode = (int)HttpStatusCode.InternalServerError;
                string details = String.Empty;
                switch (exception)
                {
                    case NotFoundException:
                        statusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case ValidationException validationException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        details = JsonObjectSerializer.SerializeObject(validationException.Errors);
                        break;
                    case BadRequestException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    default:
                        break;
                }

                await WriteErrorResponseAsync(context, exception, statusCode, details);
            }
        }

        private async Task WriteErrorResponseAsync(HttpContext context, Exception exception, 
            int statusCode, string details)
        {
            var response = new CodeErrorWithDetailsResponse(
                statusCode,
                exception.Message,
                _hostEnvironment.IsDevelopment() ? details ?? exception.StackTrace : string.Empty);

            context.Response.StatusCode = statusCode;

            await context.Response.WriteAsync(JsonObjectSerializer.SerializeObject(response));
        }
    }
}
