using ECommerce.Catalog.Apllication.Features.Products.Commands.DiscountProductPrice;
using ECommerce.Catalog.Apllication.Features.Products.Queries.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts(CancellationToken cancellationToken)
        {
            var request = new GetAllProductsQueryRequest();
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
           
        }

        [HttpPost]
        //discount product price post methodu
        public async Task<IActionResult> DiscountProductPrice([FromBody] DiscountProductPriceCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }
    }
}
