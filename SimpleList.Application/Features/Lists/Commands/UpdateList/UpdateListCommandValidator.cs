using FluentValidation;

namespace SimpleList.Application.Features.Lists.Commands.EditList
{
    public class UpdateListCommandValidator: AbstractValidator<UpdateListCommand>
    {
        public UpdateListCommandValidator()
        {
            RuleFor(l => l.Id)
                .NotNull().WithMessage("Param {Id} cannot be null")
                .GreaterThan(0).WithMessage("Param {Id} must be greater than 0");

            RuleFor(l => l.Name)
                .NotNull().WithMessage("{Name} cannot be null")
                .NotEmpty().WithMessage("{Name} cannot be empty")
                .MinimumLength(3).WithMessage("The name must be at least 3 characters long")
                .MaximumLength(50).WithMessage("The name must have a maximum of 50 characters");
        }
    }
}
