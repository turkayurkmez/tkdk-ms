using ECommerce.Catalog.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Infrastructure.Persistence
{
    public class CatalogDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasKey(c => c.Id);
            modelBuilder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(150);

            modelBuilder.Entity<Category>().Property(c => c.Description).HasMaxLength(250);


            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(p => p.Stock).IsRequired(false);
            modelBuilder.Entity<Product>().Property(p => p.CategoryId).IsRequired(false);

            modelBuilder.Entity<Product>().HasOne(p => p.Category)
                                          .WithMany(c => c.Products)
                                          .HasForeignKey(p => p.CategoryId)
                                          .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Category>().HasData(
                new Category(1, "Elektronik", "Elektronik Ürünler"),
                new Category(2, "Giyim", "Giyim Ürünler,"),
                new Category(3, "Kozmetik", "Kozmetik Ürünler")
                );






        }
    }
}
