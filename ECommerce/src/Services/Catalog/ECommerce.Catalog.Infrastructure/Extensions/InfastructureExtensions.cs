using ECommerce.Catalog.Apllication.Features.Products.Commands.DiscountProductPrice;
using ECommerce.Catalog.Domain.Repositories;
using ECommerce.Catalog.Infrastructure.EventHandlers;
using ECommerce.Catalog.Infrastructure.Persistence;
using ECommerce.Catalog.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Infrastructure.Extensions
{
    public static class InfastructureExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
         
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblyContaining<DiscountProductPriceCommandRequest>();
                config.RegisterServicesFromAssemblyContaining<ProductPriceDiscountedDomainEventHandler>();
            });
            return services;
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CatalogDbContext>(option => option.UseSqlServer(connectionString));
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;

        }
    }
}
