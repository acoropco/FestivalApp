using FestivalApp.API.Attributes;
using System.ComponentModel.DataAnnotations;

namespace FestivalApp.API.DTOs
{
    public class UserForRegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [MinimumDateOfBirth(16)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string ClientURI { get; set; }
    }
}