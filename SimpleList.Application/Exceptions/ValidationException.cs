using FluentValidation.Results;

namespace SimpleList.Application.Exceptions
{
    public class ValidationException: ApplicationException
    {
        public ValidationException() : base("Errors were found in the validation of the data received.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(string message) : base(message)
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures
                .GroupBy(f => f.PropertyName, e => e.ErrorMessage)
                .ToDictionary(f => f.Key, f => f.ToArray());
        }

        public IDictionary<string, string[]> Errors { get; set; }
    }
}
