namespace SimpleList.API.Models.Errors
{
    public class CodeErrorWithDetailsResponse: CodeErrorResponse
    {
        public string? Details { get; set; } = string.Empty;
        public CodeErrorWithDetailsResponse(int statusCode, string? errorMessage, string? details): base(statusCode, errorMessage)
        {
            Details = details;
        }
    }
}
