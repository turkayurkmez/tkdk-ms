using ECommerce.Catalog.Domain.Aggregates;
using ECommerce.Catalog.Domain.Repositories;
using ECommerce.Catalog.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Infrastructure.Repositories
{
    public class ProductRepository(CatalogDbContext catalogDbContext) : IProductRepository
    {
        //ister postgresql ister dapper.... 

        public async Task<Product> AddAsync(Product entity)
        {
            await catalogDbContext.Products.AddAsync(entity);
            await catalogDbContext.SaveChangesAsync();

            return entity;

        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await GetByIdAsync(id);
            catalogDbContext.Products.Remove(product);
            await catalogDbContext.SaveChangesAsync();


        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await catalogDbContext.Products
                                         .Include(p => p.Category) // Category bilgilerini de dahil et
                                         .AsNoTracking()
                                         .ToListAsync();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await catalogDbContext.Products
                                  .AsNoTracking()
                                  .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int id)
        {
            return await catalogDbContext.Products
                                  .AsNoTracking()
                                  .Where(p => p.CategoryId == id)
                                  .ToListAsync();
        }

        public async Task<IEnumerable<Product>> SearchByNameAsync(string name)
        {
            return await catalogDbContext.Products
                                  .AsNoTracking()
                                  .Where(p => p.Name.Contains(name))
                                  .ToListAsync();

        }

        public async Task UpdateAsync(Product entity)
        {

            catalogDbContext.Products.Update(entity);
            await catalogDbContext.SaveChangesAsync();
        }
    }
}
