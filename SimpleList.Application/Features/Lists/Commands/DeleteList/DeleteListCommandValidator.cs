using FluentValidation;

namespace SimpleList.Application.Features.Lists.Commands.DeleteList
{
    public class DeleteListCommandValidator : AbstractValidator<DeleteListCommand>
    {
        public DeleteListCommandValidator()
        {
            RuleFor(l => l.Id)
                .NotNull().WithMessage("Param {Id} cannot be null")
                .GreaterThan(0).WithMessage("Param {Id} must be greater than 0");
        }
    }
}
