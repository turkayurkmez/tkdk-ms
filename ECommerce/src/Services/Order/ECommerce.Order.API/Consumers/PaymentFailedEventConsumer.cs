using ECommerce.SharedEventBus;
using MassTransit;

namespace ECommerce.Order.API.Consumers
{
    public class PaymentFailedEventConsumer(ILogger<PaymentFailedEventConsumer> logger) : IConsumer<PaymentFailedEvent>
    {
        public Task Consume(ConsumeContext<PaymentFailedEvent> context)
        {

            // Ödeme başarısız olduğunda yapılacak işlemler
            // Örneğin, siparişi iptal etme veya kullanıcıya bildirim gönderme işlemleri burada yapılabilir.
           
            logger.LogWarning($"Ödeme başarısız: Sipariş ID: {context.Message.OrderId}, Sebep: {context.Message.Reason}");
            // İptal işlemi veya bildirim gönderme işlemleri burada yapılabilir.
            return Task.CompletedTask;

        }


    }
}
