using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace FestivalApp.API.Models
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; }
        // public string City { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}