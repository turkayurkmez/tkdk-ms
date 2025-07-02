using ECommerce.SharedEventBus;
using MassTransit;

namespace ECommerce.Payment.API.Consumers
{
    public class StockAvailableEventConsumer(ILogger<StockAvailableEventConsumer> logger) : IConsumer<StockAvailableEvent>
    {
        public async Task Consume(ConsumeContext<StockAvailableEvent> context)
        {
            var command = context.Message.Command;
            var isSuccess = new Random().Next(0, 2) == 1; // Rastgele ödeme işlemi başarılı mı kontrolü yapılıyor, gerçek ödeme işlemi burada yapılmalı.

            if (isSuccess)
            {
                var @event = new PaymentSuccessEvent(command.OrderId);
                await context.Publish(@event);

                // Ödeme başarılı ise, gerekli işlemleri yap
                logger.LogInformation($"Ödeme başarılı: Sipariş ID: {command.OrderId}, Müşteri ID: {command.CustomerId}, Toplam Fiyat: {command.TotalPrice}");
            }
            else
            {
                var @event = new PaymentFailedEvent(command.OrderId,"Bakiye yetersiz!");
                await context.Publish(@event);
                // Ödeme başarısız ise, gerekli işlemleri yap
                logger.LogInformation($"Ödeme başarısız: Sipariş ID: {command.OrderId}, Müşteri ID: {command.CustomerId} sebebi");
            }

        }
    }
}
