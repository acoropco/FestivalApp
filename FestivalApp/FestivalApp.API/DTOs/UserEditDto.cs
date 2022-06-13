using System.ComponentModel.DataAnnotations;

namespace FestivalApp.API.DTOs
{
    public class UserEditDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}