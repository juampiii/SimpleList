using FluentValidation;
using MediatR;
using ValidationException = SimpleList.Application.Exceptions.ValidationException;

namespace SimpleList.Application.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest: IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validatiors;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validatiors)
        {
            _validatiors = validatiors;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (!_validatiors.Any())
                return await next();

            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(_validatiors.Select(v => v.ValidateAsync(context, cancellationToken)));

            var failures = validationResults
                .SelectMany(r => r.Errors)
                .Where(f => f != null);

            if (!failures.Any())
            {
                return await next();
            }

            throw new ValidationException(failures);
        }
    }
}
