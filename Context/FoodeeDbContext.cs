using FOODEE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Context
{
    public class FOODEEDbContext : DbContext
    {
        public FOODEEDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<SuperAdmin> SuperAdmins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuMenuItem> MenuMenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        //public DbSet<Payment> Payments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Cart>()
                .HasMany(c => c.CartItems)
                .WithOne(c => c.Cart)
                .HasForeignKey(ci => ci.CartId);

            modelBuilder.Entity<Cart>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Menu>()
                .HasMany(m => m.MenuMenuItems)
                .WithOne(mmi => mmi.Menu)
                .HasForeignKey(mmi => mmi.MenuId);

            modelBuilder.Entity<MenuItem>()
                .HasMany(m => m.MenuMenuItems)
                .WithOne(mmi => mmi.MenuItem)
                .HasForeignKey(mmi => mmi.MenuItemId);

            //modelBuilder.Entity<Order>()
            //    .HasOne(o => o.Payment)
            //    .WithOne(p => p.Order)
            //    .HasForeignKey<Order>(o => o.PaymentId);


            // Configure One To One Between User And Customer, Admin and SuperAdmin

            modelBuilder.Entity<User>()
                .HasOne(u => u.Admin)
                .WithOne(a => a.User);

            modelBuilder.Entity<User>()
                .HasOne(u => u.SuperAdmin)
                .WithOne(sa => sa.User);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Customer)
                .WithOne(c => c.User);

            // configuring one to many between customer and cart
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Carts)
                .WithOne(cr => cr.Customer)
                .HasForeignKey(cr => cr.userId);

            // configuring one to many between customer and Payment
            //modelBuilder.Entity<Customer>()
            //    .HasMany(c => c.Payments)
            //    .WithOne(p => p.Customer)
            //    .HasForeignKey(p => p.userId);

            // configuring one to many between customer and Order
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.userId);


            // Configuring Customer Primary Key 
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.UserId);

            // Configuring Admin Primary Key 
            modelBuilder.Entity<Admin>()
                .HasKey(a => a.UserId);

            // Configuring Super Admin Primary Key 
            modelBuilder.Entity<SuperAdmin>()
                .HasKey(sa => sa.UserId);
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
                },
                new User
                {
                    Id = 2,
                    FirstName = "Risqah",
                    LastName = "Olowonmi",
                    CreatedAt = DateTime.Now,
                    Gender = "Female",
                    Email = "risqah@gmail.com",
                    PhoneNumber = "08054593619",
                    Address = "Asero,Abk",
                    PasswordHash = "6prgwCkzdfZ/oANfSVHfdcE7vzXvVhWSA5WXj8AhHxs=",
                    HashSalt = "oRG1o9cidyVnRFgsWQN7AA=="
                }
            );
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "superadmin",
                    CreatedAt = DateTime.Now
                },
                new Role
                {
                    Id = 2,
                    Name = "admin",
                    CreatedAt = DateTime.Now
                }, new Role
                {
                    Id = 3,
                    Name = "customer",
                    CreatedAt = DateTime.Now
                }

            );

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    Id = 1,
                    UserId = 1,
                    RoleId = 1,
                    CreatedAt = DateTime.Now
                },
                new UserRole
                {
                    Id = 2,
                    UserId = 2,
                    RoleId = 2,
                    CreatedAt = DateTime.Now
                }
            );

            modelBuilder.Entity<SuperAdmin>().HasData(
                new SuperAdmin
                {
                    UserId = 1
                }
            );
            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    UserId = 1
                }
            );
        }
    }
}