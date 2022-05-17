
using System.Net;

namespace SimpleList.Application.Exceptions
{
    public class NotFoundException : CustomApplicationExceptionBase
    {
        public NotFoundException(string message) : base((int)HttpStatusCode.NotFound, message)
        {
        }
    }
}
