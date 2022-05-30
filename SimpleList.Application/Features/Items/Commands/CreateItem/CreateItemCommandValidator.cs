using FluentValidation;

namespace SimpleList.Application.Features.Items.Commands.CreateItem
{
    public class CreateItemCommandValidator: AbstractValidator<CreateItemCommand>
    {
        public CreateItemCommandValidator() 
        {
            RuleFor(i => i.ListId)
                .NotNull().WithMessage("{ListId} cannot be null")
                .GreaterThan(0).WithMessage("{ListId} must have a valid value");

            RuleFor(i => i.Description)
                .NotNull().WithMessage("{Description} value is required")
                .NotEmpty().WithMessage("{Description} value is required");

            RuleFor(i => i.Quantity)
                .NotNull().WithMessage("{Quantity} must have a valid value")
                .GreaterThan(0).WithMessage("{Quantity} must have a valid value");
        }
    }
}
