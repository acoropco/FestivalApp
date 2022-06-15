using Microsoft.AspNetCore.Identity;

namespace FestivalApp.Domain.Entities
{
    public class RoleEntity : IdentityRole<int>
    {
        public virtual ICollection<UserRoleEntity> UserRoles { get; set; }
    }
}