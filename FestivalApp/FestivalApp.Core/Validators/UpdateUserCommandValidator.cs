using FestivalApp.Core.Commands.UpdateUser;
using FluentValidation;
using System.Text.RegularExpressions;

namespace FestivalApp.Core.Validators
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(u => u.UserUpdateModel.FirstName)
                .NotEmpty().WithMessage("First name cannot be empty.")
                .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");

            RuleFor(u => u.UserUpdateModel.LastName)
                .NotEmpty().WithMessage("Last name cannot be empty.")
                .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");

            RuleFor(u => u.UserUpdateModel.DateOfBirth.Date)
                .LessThanOrEqualTo(DateTime.Now.Date.AddYears(-16)).WithMessage("You must be at least 16 years old.");

            RuleFor(u => u.UserUpdateModel.PhoneNumber)
                .Matches(new Regex(@"\d{10}")).WithMessage("Phone number is not valid.");
        }
    }
}
