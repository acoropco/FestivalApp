using Microsoft.AspNetCore.Identity;

namespace FestivalApp.Domain.Entities
{
    public class Role : IdentityRole<int>
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}