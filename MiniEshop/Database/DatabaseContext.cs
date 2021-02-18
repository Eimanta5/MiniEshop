using Microsoft.EntityFrameworkCore;
using MiniEshop.Database.Entities;
using System;

namespace MiniEshop.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartProduct> ShoppingCartProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<User>()
                .ToTable("User")
                .HasData(
                new User
                {
                    Id = 1,
                    Name = "Basic",
                    Surname = "User",
                    Email = "basic@email.com",
                    IsAdministration = false,
                    Created = DateTime.UtcNow,
                    Password = "password",
                    PhoneNumber = "+37065555555"
                },

                new User
                {
                    Id = 2,
                    Name = "Administration",
                    Surname = "User",
                    Email = "admin@email.com",
                    IsAdministration = true,
                    Created = DateTime.UtcNow,
                    Password = "password",
                    PhoneNumber = "+37065555155"
                });

            modelBuilder.Entity<ShoppingCart>()
                .ToTable("ShoppingCart")
                .HasData(
                new ShoppingCart
                {
                    Id = 1,
                    IsActive = true,
                    UserId = 1,
                    DateCreated = DateTime.UtcNow
                });

            modelBuilder.Entity<ShoppingCartProduct>().ToTable("ShoppingCartProduct");
        }
    }
}
