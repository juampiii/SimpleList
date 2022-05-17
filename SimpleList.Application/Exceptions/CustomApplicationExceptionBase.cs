namespace SimpleList.Application.Exceptions
{
    public abstract class CustomApplicationExceptionBase : ApplicationException
    {
        protected string _details { get; set; }
        public virtual int StatusCode { get; set; }
        public virtual string? Message { get; set; } = string.Empty;
        public virtual string? Details
        {
            get
            {
                return _details ?? StackTrace;
            }
        }

        public CustomApplicationExceptionBase(int statusCode)
        {
            StatusCode = statusCode;
        }

        public CustomApplicationExceptionBase(int statusCode, string message) : base(message)
        {
            Message = message;
            StatusCode = statusCode;
        }
    }
}
