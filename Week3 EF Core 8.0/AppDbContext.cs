using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RetailInventory.Models;

namespace RetailInventory
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=BT-22054128\\SQLEXPRESS;Database=RetailInventoryDB;Trusted_connection=yes;TrustServerCertificate=True");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasData(
                new Category { CategoryId = 1, Name= "Electronics"},
                new Category { CategoryId = 2, Name = "Groceries" }
                );

            modelBuilder.Entity<Product>()
                .HasData(
                new Product
                {
                    Id = 1,
                    Name = "Smartphone",
                    Price = 25000,
                    StockQuantity = 50,
                    CategoryId =1
                },

                new Product
                {
                    Id = 2,
                    Name = "Wheat Flour",
                    Price = 800,
                    StockQuantity = 100,
                    CategoryId = 2
                }
                );

            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductDetail)
                .WithOne(pd => pd.Product)
                .HasForeignKey<ProductDetail>(pd => pd.ProductId);
        }
    }
}
