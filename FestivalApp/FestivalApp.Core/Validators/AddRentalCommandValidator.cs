using FestivalApp.Core.Commands.AddRental;
using FluentValidation;

namespace FestivalApp.Core.Validators
{
    public class AddRentalCommandValidator : AbstractValidator<AddRentalCommand>
    {
        public AddRentalCommandValidator()
        {
            RuleFor(r => r.Rental.Name)
                .NotEmpty().WithMessage("Rental name cannot be empty.")
                .MaximumLength(100).WithMessage("Rental name cannot exceed 100 characters.");

            RuleFor(r => r.Rental.County)
                .NotEmpty().WithMessage("County name cannot be empty.")
                .MaximumLength(100).WithMessage("County name cannot exceed 100 characters.");

            RuleFor(r => r.Rental.City)
                .NotEmpty().WithMessage("City name cannot be empty.")
                .MaximumLength(100).WithMessage("City name cannot exceed 100 characters.");

            RuleFor(r => r.Rental.Street)
                .NotEmpty().WithMessage("Street name cannot be empty.")
                .MaximumLength(100).WithMessage("Street name cannot exceed 100 characters.");
        }
    }
}
