using ECommerce.SharedEventBus;
using MassTransit;

namespace ECommerce.Basket.API.Consumers
{
    public class BasketProductPriceDiscountedConsumer(ILogger<BasketProductPriceDiscountedConsumer> logger) : IConsumer<ProductPriceDiscountedEvent>
    {
        public Task Consume(ConsumeContext<ProductPriceDiscountedEvent> context)
        {

            logger.LogInformation($"{context.Message.ProductId} id'li ürünün fiyatı {context.Message.OldPrice} TL'den {context.Message.NewPrice} TL'ye düşürüldü.");
            // Sepetteki ürünlerin fiyatlarını güncelleme işlemleri burada yapılabilir.
            // Örneğin, sepet veritabanında ilgili ürünün fiyatını güncellemek gibi.
            // redis üzerinde sepetleri tutuyorsam; o sepetlerdeki ilgili ürünün fiyatını güncelleme işlemi burada yapılabilir.
            return Task.CompletedTask;

        }
    }
}
