using System;
using Microsoft.AspNetCore.Identity;

namespace FestivalApp.Domain.Entities
{
    public class UserRole : IdentityUserRole<int>
    {
        public virtual User User { get; set; }

        public virtual Role Role { get; set; }
    }
}