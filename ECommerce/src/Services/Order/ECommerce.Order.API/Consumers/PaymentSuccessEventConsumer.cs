using ECommerce.SharedEventBus;
using MassTransit;

namespace ECommerce.Order.API.Consumers
{
    public class PaymentSuccessEventConsumer(ILogger<PaymentSuccessEventConsumer> logger) : IConsumer<PaymentSuccessEvent>
    {
        public Task Consume(ConsumeContext<PaymentSuccessEvent> context)
        {
            // Ödeme başarılı olduğunda yapılacak işlemler
            // Örneğin, siparişi onaylama veya kullanıcıya bildirim gönderme işlemleri burada yapılabilir.
            
            logger.LogInformation($"Ödeme başarılı: Sipariş ID: {context.Message.OrderId}");
            // Onaylama işlemi veya bildirim gönderme işlemleri burada yapılabilir.
            return Task.CompletedTask;
        }
    }
}
