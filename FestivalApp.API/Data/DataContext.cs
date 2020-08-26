using System;
using FestivalApp.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FestivalApp.API.Data
{
    public class DataContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>,
        UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Festival> Festivals { get; set; }
        public DbSet<RentalPhoto> RentalPhotos { get; set; }
        public DbSet<UserFestival> UserFestivals { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRole>(userRole => {
                userRole.HasKey(ur => new {ur.UserId, ur.RoleId});

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            builder.Entity<UserFestival>()
              .HasKey(k => new {k.UserId, k.FestivalId});
            
            builder.Entity<UserFestival>()
              .HasOne(sf => sf.User)
              .WithMany(sf => sf.UserFestivals)
              .HasForeignKey(sf => sf.UserId);

            builder.Entity<UserFestival>()
              .HasOne(sf => sf.Festival)
              .WithMany(sf => sf.UserFestivals)
              .HasForeignKey(sf => sf.FestivalId); 
        }
    }
}