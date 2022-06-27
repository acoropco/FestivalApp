using FestivalApp.Core.Commands.AddRental;
using FluentValidation;

namespace FestivalApp.Core.Validators
{
    public class AddRentalCommandValidator : AbstractValidator<AddRentalCommand>
    {
        public AddRentalCommandValidator()
        {
            RuleFor(r => r.Rental.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(r => r.Rental.County)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(r => r.Rental.City)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(r => r.Rental.Street)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
