using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Apllication.Features.Products.Commands.CreateProduct
{

    //1. Eylemin ihtiyaç duyduğu verileri taşıyan nesne. (Request)
    public record CreateProductCommandRequest(string Name, string Description, decimal Price, int? Stock, int? CategoryId=null, string ImageUel ="noimage.png") : IRequest<CreateProductCommandResponse> ;

    //3.Eylem gerçekleştikten sonra olup biteni tutan nesne! (Response)

    public record CreateProductCommandResponse(bool IsSuccess, Guid CreatedProduct, string? ErrorMessages = null);

}
