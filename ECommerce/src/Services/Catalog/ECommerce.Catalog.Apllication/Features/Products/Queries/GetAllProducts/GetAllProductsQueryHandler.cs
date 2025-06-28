using ECommerce.Catalog.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Apllication.Features.Products.Queries.GetAllProducts
{
    //ne yapar? // Tüm ürünleri getirir.
    internal class GetAllProductsQueryHandler(IProductRepository productRepository) : IRequestHandler<GetAllProductsQueryRequest, GetAllProductsQueryResponse>
    {
        public async Task<GetAllProductsQueryResponse> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await productRepository.GetAllAsync();

            var dtos = products.Select(p => new ProductListResponse(Id: p.Id,
                                                                    Name: p.Name,
                                                                    Description: p.Description,
                                                                    Price: p.Price,
                                                                    Stock: p.Stock,
                                                                    CategoryId: p.CategoryId,
                                                                    CategoryName:p.Category.Name));

            
            var response = new GetAllProductsQueryResponse(Products: dtos.ToList());

            return response;

        }
    }
}
