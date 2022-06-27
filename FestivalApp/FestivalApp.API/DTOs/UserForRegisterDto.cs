using System.ComponentModel.DataAnnotations;

namespace FestivalApp.API.DTOs
{
    public class UserForRegisterDto
    {
        [Required]
        [EmailAddress]
        public string Username { get; set; }

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
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string ClientURI { get; set; }
    }
}