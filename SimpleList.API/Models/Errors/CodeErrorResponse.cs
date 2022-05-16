using System.Net;

namespace SimpleList.API.Models.Errors
{
    public class CodeErrorResponse
    {
        public int StatusCode { get; set; }
        public string? ErrorMessage { get; set; }

        public CodeErrorResponse(int statusCode, string? errorMessage)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage ?? GetDefaultErrorMessage(statusCode);
        }

        private string? GetDefaultErrorMessage(int statusCode)
        {
            return statusCode switch
            {
                (int)HttpStatusCode.BadRequest => "Request is not valid",
                (int)HttpStatusCode.Unauthorized => "User is not authorised to perform the requested",
                (int)HttpStatusCode.NotFound => "Resource does not exist",
                (int)HttpStatusCode.InternalServerError => "Internal server error",
                _ => default
            };
        }
    }
}
