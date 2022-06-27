using System.ComponentModel.DataAnnotations;

namespace FestivalApp.API.Attributes
{
    public class MinimumDateOfBirth : ValidationAttribute
    {
        private readonly int _minimumAge;

        public MinimumDateOfBirth(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dateOfBirth = (DateTime)value;

            if (DateTime.Now.Date.AddYears(-_minimumAge) >= dateOfBirth.Date)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult($"You must be at least {_minimumAge} years old.");
            }
        }
    }
}
