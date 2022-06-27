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
        public DateTime DateOfBirth { get; set; }

        public string ClientURI { get; set; }
    }
}