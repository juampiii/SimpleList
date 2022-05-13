using FluentValidation;

namespace SimpleList.Application.Features.Lists.Commands.CreateList
{
    public class CreateListCommandValidator: AbstractValidator<CreateListCommand>
    {
        public CreateListCommandValidator()
        {
            RuleFor(l => l.Name)
                .NotNull().WithMessage("{Name} cannot be null")
                .NotEmpty().WithMessage("{Name} cannot be empty")
                .MinimumLength(3).WithMessage("The name must be at least 3 characters long")
                .MaximumLength(50).WithMessage("The name must have a maximum of 50 characters");
        }
    }
}
