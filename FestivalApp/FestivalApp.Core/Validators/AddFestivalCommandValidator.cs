using FestivalApp.Core.Commands.AddFestival;
using FluentValidation;

namespace FestivalApp.Core.Validators
{
    public class AddFestivalCommandValidator : AbstractValidator<AddFestivalCommand>
    {
        public AddFestivalCommandValidator()
        {
            RuleFor(f => f.Festival.Name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(f => f.Festival.StartDate)
                .NotEmpty()
                .GreaterThanOrEqualTo(DateTime.Now.Date);

            RuleFor(f => f.Festival.EndDate)
                .NotEmpty()
                .GreaterThanOrEqualTo(f => f.Festival.StartDate)
                .LessThan(f => f.Festival.StartDate.AddYears(1));

            RuleFor(f => f.Festival.ImageUrl)
                .NotEmpty();

            RuleFor(f => f.Festival.Street)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(f => f.Festival.City)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
