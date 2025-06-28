using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Apllication.Features.Products.Queries.GetAllProducts
{
    public record GetAllProductsQueryRequest() :IRequest<GetAllProductsQueryResponse>;

    public record GetAllProductsQueryResponse(List<ProductListResponse> Products);

    public record ProductListResponse(Guid Id, string Name, string Description, decimal Price, int? Stock, int? CategoryId, string CategoryName);

}
  
