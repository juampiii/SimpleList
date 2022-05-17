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
            catch (CustomApplicationExceptionBase customException)
            {
                _logger.LogError(customException, customException.Message);
                await WriteErrorResponseAsync(context, customException.StatusCode, customException.Message, customException.Details);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                await WriteErrorResponseAsync(context, (int)HttpStatusCode.InternalServerError, exception.Message, exception.StackTrace);
            }
        }

        private async Task WriteErrorResponseAsync(HttpContext context, int statusCode, string? message, string? details)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            CodeErrorWithDetailsResponse response = new CodeErrorWithDetailsResponse(
                statusCode, message, _hostEnvironment.IsDevelopment() ? details : string.Empty);

            await context.Response.WriteAsync(JsonObjectSerializer.SerializeObject(response));
        }
    }
}
