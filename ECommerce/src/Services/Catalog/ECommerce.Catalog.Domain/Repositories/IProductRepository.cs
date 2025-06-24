using ECommerce.Catalog.Domain.Aggregates;
using ECommerce.SharedLibrary.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Domain.Repositories
{
    public interface IProductRepository: IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int id);
        Task<IEnumerable<Product>> SearchByNameAsync(string name);
    }
}
