using ECommerce.SharedEventBus;
using MassTransit;

namespace ECommerce.Order.API.Consumers
{
    public class OrderProductPriceDiscountedConsumer : IConsumer<ProductPriceDiscountedEvent>
    {
        private readonly ILogger<OrderProductPriceDiscountedConsumer> _logger;
        public OrderProductPriceDiscountedConsumer(ILogger<OrderProductPriceDiscountedConsumer> logger)
        {
            _logger = logger;
        }
        public Task Consume(ConsumeContext<ProductPriceDiscountedEvent> context)
        {
            _logger.LogInformation($"Bu service order microservisi.... {context.Message.ProductId} id'li ürünün fiyatı {context.Message.OldPrice} TL'den {context.Message.NewPrice} TL'ye düşürüldü.");
            // Siparişlerdeki ürünlerin fiyatlarını güncelleme işlemleri burada yapılabilir.
            // Örneğin, sipariş veritabanında ilgili ürünün fiyatını güncellemek gibi.
            return Task.CompletedTask;
        }
    }
    
}
