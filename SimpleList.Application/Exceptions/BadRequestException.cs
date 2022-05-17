using System.Net;

namespace SimpleList.Application.Exceptions
{
    public class BadRequestException : CustomApplicationExceptionBase
    {
        public BadRequestException(string message) : base((int)HttpStatusCode.BadRequest, message)
        {
        }
    }
}
