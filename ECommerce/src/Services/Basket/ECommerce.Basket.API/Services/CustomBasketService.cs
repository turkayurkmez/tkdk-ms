using ECommerce.Basket.API.Protos;
using Grpc.Core;
using static ECommerce.Basket.API.Protos.BasketService;

namespace ECommerce.Basket.API.Services
{
    public class CustomBasketService(ILogger<CustomBasketService> logger) : BasketServiceBase
    {
        public override Task<BasketResponse> GetBasket(GetBasketRequest request, ServerCallContext context)
        {
            //örnek: redis'ten kayıtlı müşteriye ait edilen sepeti getirebilirdik:
            var response = new BasketResponse
            {
                BuyerId = "test-user-1",
                Items = {
                    new BasketItem { ProductId = "product-1", ProductName="Ürün A", Quantity = 2, Price = 100 },
                    new BasketItem { ProductId = "product-2", ProductName="Ürün B", Quantity = 1, Price = 50 } }
            };

            return Task.FromResult(response);
        }


        public override Task<BasketResponse> AddItemToBasket(AddItemToBasketRequest request, ServerCallContext context)
        {
            //örnek: redis'e sepet ekleme işlemi yapılabilirdi:
            var response = new BasketResponse
            {
                BuyerId = request.BuyerId,
                Items = {
                    new BasketItem { ProductId = request.Item.ProductId, ProductName=request.Item.ProductName, Quantity = request.Item.Quantity, Price = request.Item.Price } }
            };
            return Task.FromResult(response);
        
        }

        // UpdateBasket metodunu da benzer şekilde implement edebilirsiniz:
        public override Task<BasketResponse> UpdateBasket(UpdateBasketRequest request, ServerCallContext context)
        {
            //örnek: redis'te sepet güncelleme işlemi yapılabilirdi:
            var response = new BasketResponse
            {
                BuyerId = request.BuyerId,
                Items = {
                    new BasketItem { ProductId = "1", ProductName="request.Item.ProductName", Quantity = 8, Price = request.Items[0].Price } }
            };
            return Task.FromResult(response);
        }

    }



    // Implement your service methods here, for example:
    // public override Task<YourResponseType> YourMethod(YourRequestType request, ServerCallContext context)
    // {
    //     // Your logic here
    // }
}
    

