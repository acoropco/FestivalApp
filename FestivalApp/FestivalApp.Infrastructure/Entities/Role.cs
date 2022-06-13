using Microsoft.AspNetCore.Identity;

namespace FestivalApp.Infrastructure.Entities
{
    public class Role : IdentityRole<int>
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}