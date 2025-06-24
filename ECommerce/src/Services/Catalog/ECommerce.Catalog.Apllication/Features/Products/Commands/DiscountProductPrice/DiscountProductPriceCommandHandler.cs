
using ECommerce.Catalog.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Apllication.Features.Products.Commands.DiscountProductPrice
{
    internal class DiscountProductPriceCommandHandler(IProductRepository productRepository) : IRequestHandler<DiscountProductPriceCommandRequest, DiscountProductPriceCommandResponse>
    {
        public async Task<DiscountProductPriceCommandResponse> Handle(DiscountProductPriceCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.ProductId);

            if (product is null)
            {
                return new DiscountProductPriceCommandResponse(IsSuccess: false, Message: $"{request.ProductId} id'li ürün bulunamadı");
            }

            product.ApplyDiscount(request.DiscountRate);
             await productRepository.UpdateAsync(product);

            return new DiscountProductPriceCommandResponse(true, $"{request.ProductId} id'li ürüne {request.DiscountRate} kadar indirim yapıldı");

        }
    }
}
