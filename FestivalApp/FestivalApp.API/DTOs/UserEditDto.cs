using System.ComponentModel.DataAnnotations;

namespace FestivalApp.API.DTOs
{
    public class UserEditDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PhoneNumber { get; set; }
    }
}