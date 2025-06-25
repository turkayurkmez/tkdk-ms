using ECommerce.Catalog.Domain.Aggregates;
using ECommerce.SharedLibrary.Domain;
using MediatR;
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
        private readonly IMediator _mediator;


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


            modelBuilder.Entity<Product>().HasData(
                new Product("Samsung Galaxy S21", "Akıllı telefon", 9999.99m,50,1),
                new Product("Apple iPhone 13", "Akıllı telefon", 12999.99m, 30, 1),
                new Product("Nike Air Max", "Spor ayakkabı", 799.99m, 100, 2),
                new Product("L'Oréal Paris Şampuan", "Saç şampuanı", 49.99m, 200, 3)

            );




        }

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options, IMediator mediator):base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //1. İçinde domain event barındıran entity'leri alalım
            var domainEntities = ChangeTracker.Entries<IAggregateRoot>()
                .Where(e => e.Entity.DomainEvents != null && e.Entity.DomainEvents.Any())
                .Select(e => e.Entity);

            //2. Bu entity'lerin domain event'lerini alalım
            var domainEvents = domainEntities.SelectMany(e => e.DomainEvents).ToList();

            //3. İlgili olayları tetikleyelim
            foreach (var domainEvent in domainEvents)
            {
               _mediator.Publish(domainEvent, cancellationToken);
            }

            //4. Domain event'leri temizleyelim
            foreach (var entity in domainEntities)
            {
                entity.ClearDomainEvents();
            }

            //5. Değişiklikleri kaydedelim
            return base.SaveChangesAsync(cancellationToken);


        }
    }
}
