using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Apllication.Features.Products.Commands.DiscountProductPrice
{
    public record DiscountProductPriceCommandRequest(Guid ProductId, decimal DiscountRate):IRequest<DiscountProductPriceCommandResponse>;

    public record DiscountProductPriceCommandResponse(bool IsSuccess, string Message);
    
}
