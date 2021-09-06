using FOODEE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Context
{
    public class FoodeeDbContext : DbContext
    {
        public FoodeeDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuMenuItem> MenuMenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>(o =>
            {
                o.HasIndex(o => new { o.MenuId, o.OrderId }).IsUnique();

                modelBuilder.Entity<User>().Property(u => u.Id).IsRequired();
                modelBuilder.Entity<Role>().HasIndex(u => u.Id).IsUnique();
                modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
                modelBuilder.Entity<MenuItem>().HasKey(s => s.Id);
                modelBuilder.Entity<Order>().HasKey(s => s.Id);
                modelBuilder.Entity<OrderItem>().HasKey(s => s.Id);
                modelBuilder.Entity<User>().Property(u => u.Email)
                    .IsRequired();
                modelBuilder.Entity<UserRole>().HasKey(ur => ur.Id);
                modelBuilder.Entity<UserRole>().HasIndex(U => U.UserId);
                modelBuilder.Entity<UserRole>().HasIndex(u => u.RoleId);
                modelBuilder.Entity<User>().HasMany(u => u.UserRoles)
                    .WithOne(ur => ur.User)
                    .HasForeignKey(ur => ur.UserId);
                modelBuilder.Entity<Role>().HasMany(r => r.UserRoles)
                    .WithOne(r => r.Role)
                    .HasForeignKey(r => r.RoleId);
                modelBuilder.Entity<User>().HasData(
                      new User
                      {
                          Id = 1,
                          FirstName = "Habeebah",
                          LastName = "Olowonmi",
                          CreatedAt = DateTime.Now,
                          Gender = "Female",
                          Email = "olowonmiadejoke@gmail.com",
                          PhoneNumber = "09039513977",
                          Address = "Asero,Abk",
                          PasswordHash = "6prgwCkzdfZ/oANfSVHfdcE7vzXvVhWSA5WXj8AhHxs=",
                          HashSalt = "oRG1o9cidyVnRFgsWQN7AA=="
                      }
                    );
                modelBuilder.Entity<Role>().HasData(
                 new Role { Id = 1, Name = "SuperAdmin", CreatedAt = DateTime.Now }, new Role { Id = 2, Name = "Admin", CreatedAt = DateTime.Now }, new Role { Id = 3, Name = "Customer", CreatedAt = DateTime.Now }
                );

                modelBuilder.Entity<UserRole>().HasData(new UserRole { Id = 1, UserId = 1, RoleId = 1, CreatedAt = DateTime.Now });

                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<Menu>().HasMany(m => m.MenuItems)
                .WithOne(m => m.Manu)
                .HasForeignKey(m => m.MenuId).OnDelete(DeleteBehavior.Restrict);
                modelBuilder.Entity<MenuItem>().HasMany(m => m.Menus)
                .WithOne(m => m.MenuItem)
                .HasForeignKey(m => m.MenuItemId).OnDelete(DeleteBehavior.Restrict);
            });
        }
    }   
}
