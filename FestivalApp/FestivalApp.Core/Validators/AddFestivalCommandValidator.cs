using FestivalApp.Core.Commands.AddFestival;
using FluentValidation;

namespace FestivalApp.Core.Validators
{
    public class AddFestivalCommandValidator : AbstractValidator<AddFestivalCommand>
    {
        public AddFestivalCommandValidator()
        {
            RuleFor(f => f.Festival.Name)
                .NotEmpty().WithMessage("Festival name cannot be empty.")
                .MaximumLength(50).WithMessage("Festival name cannot exceed 50 characters.");

            RuleFor(f => f.Festival.StartDate.Date)
                .NotNull().WithMessage("Start date is invalid.")
                .GreaterThanOrEqualTo(DateTime.Now.Date).WithMessage($"Start date cannot be lesser than {DateTime.Now.ToString("dd-MMM-yyyy")}.");

            RuleFor(f => f.Festival.EndDate.Date)
                .NotNull().WithMessage("End date is invalid.")
                .GreaterThanOrEqualTo(f => f.Festival.StartDate.Date).WithMessage($"End date must be greater than the start date.")
                .LessThan(f => f.Festival.StartDate.Date.AddYears(1)).WithMessage("End date cannot surpass one year since it started.");

            RuleFor(f => f.Festival.ImageUrl)
                .NotEmpty().WithMessage("Image Url cannot be empty.");

            RuleFor(f => f.Festival.Street)
                .NotEmpty().WithMessage("Street name cannot be empty.")
                .MaximumLength(100).WithMessage("Street name cannot exceed 100 characters.");

            RuleFor(f => f.Festival.City)
                .NotEmpty().WithMessage("City name cannot be empty.")
                .MaximumLength(100).WithMessage("City name cannot exceed 100 characters.");

            RuleFor(f => f.Festival.County)
                .NotEmpty().WithMessage("County name cannot be empty.")
                .MaximumLength(100).WithMessage("County name cannot exceed 100 characters.");
        }
    }
}
