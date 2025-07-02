using ECommerce.SharedEventBus;
using MassTransit;

namespace ECommerce.Order.API.Consumers
{
    public class StockNotAvailableEventConsumer(ILogger<StockNotAvailableCommand> logger) : IConsumer<StockNotAvailableEvent>
    {
        public Task Consume(ConsumeContext<StockNotAvailableEvent> context)
        {
            // Stok yetersiz olduğunda yapılacak işlemler
            // Örneğin, siparişi iptal etme veya kullanıcıya bildirim gönderme işlemleri burada yapılabilir.
           
            logger.LogWarning($"Stok yetersiz: Sipariş ID: {context.Message.Command.OrderId}");
            // İptal işlemi veya bildirim gönderme işlemleri burada yapılabilir.
            return Task.CompletedTask;

        }
    }
}
