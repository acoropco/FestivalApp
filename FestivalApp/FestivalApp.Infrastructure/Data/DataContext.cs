﻿using FestivalApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FestivalApp.Infrastructure.Data
{
    public class DataContext : IdentityDbContext<UserEntity, RoleEntity, int, IdentityUserClaim<int>,
        UserRoleEntity, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<RentalEntity> Rentals { get; set; }

        public DbSet<FestivalEntity> Festivals { get; set; }

        public DbSet<RentalPhotoEntity> RentalPhotos { get; set; }

        public DbSet<UserFestivalEntity> UserFestivals { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRoleEntity>(userRole => {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            builder.Entity<UserFestivalEntity>()
              .HasKey(k => new { k.UserId, k.FestivalId });

            builder.Entity<UserFestivalEntity>()
              .HasOne(sf => sf.User)
              .WithMany(sf => sf.UserFestivals)
              .HasForeignKey(sf => sf.UserId);

            builder.Entity<UserFestivalEntity>()
              .HasOne(sf => sf.Festival)
              .WithMany(sf => sf.UserFestivals)
              .HasForeignKey(sf => sf.FestivalId);
        }
    }
}