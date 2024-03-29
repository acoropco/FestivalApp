using System;
using System.ComponentModel.DataAnnotations;

namespace FestivalApp.API.Dtos
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
        // [Required]
        // public string Country { get; set; }
        // [Required]
        // public string City { get; set; }
        public DateTime Created { get; set; }
        public string ClientURI { get; set; }

        public UserForRegisterDto()
        {
            Created = DateTime.Now;
        }
    }
}