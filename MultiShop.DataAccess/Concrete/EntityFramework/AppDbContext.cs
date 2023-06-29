using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MultiShop.Core.Entities.Concrete;
using MultiShop.Entities.Concrete;

namespace MultiShop.DataAccess.Concrete.EntityFramework
{
	public class AppDbContext : IdentityDbContext<User>
	{
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=127.0.0.1,1433;Database=K101Test; User Id=SA; Password=Ehmed123; TrustServerCertificate=True;");
        }

        public DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
        }

    }
}

