using FluentValidation.Results;
using SimpleList.Application.Utils;
using System.Net;

namespace SimpleList.Application.Exceptions
{
    public class ValidationException : CustomApplicationExceptionBase
    {
        public ValidationException() : base((int)HttpStatusCode.BadRequest, "Errors were found in the validation of the data received.")
        {
        }

        public ValidationException(string message) : base((int)HttpStatusCode.BadRequest, message)
        {
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            if (failures?.Any() != true)
            {
                return;
            }

           var ValidationErrors = failures
                .GroupBy(f => f.PropertyName, e => e.ErrorMessage)
                .ToDictionary(f => f.Key, f => f.ToArray());

            _details = JsonObjectSerializer.SerializeObject(ValidationErrors);
        }
    }
}
