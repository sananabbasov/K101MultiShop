using System;
using Microsoft.EntityFrameworkCore;
using MultiShop.Entities.Concrete;

namespace MultiShop.DataAccess.Concrete.EntityFramework
{
	public class AppDbContext : DbContext
	{
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=127.0.0.1,1433;Database=K101Test; User Id=SA; Password=Ehmed123; TrustServerCertificate=True;");
        }

        public DbSet<Product> Products { get; set; }
    }
}

