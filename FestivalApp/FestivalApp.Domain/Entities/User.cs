using Microsoft.AspNetCore.Identity;

namespace FestivalApp.Domain.Entities
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime Created { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }

        public virtual ICollection<Rental> Rentals { get; set; }

        public virtual ICollection<UserFestival> UserFestivals { get; set; }
    }
}