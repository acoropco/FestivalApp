using Microsoft.AspNetCore.Identity;

namespace FestivalApp.Domain.Entities
{
    public class UserEntity : IdentityUser<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime Created { get; set; }

        public virtual ICollection<UserRoleEntity> UserRoles { get; set; }

        public virtual ICollection<RentalEntity> Rentals { get; set; }

        public virtual ICollection<UserFestivalEntity> UserFestivals { get; set; }
    }
}