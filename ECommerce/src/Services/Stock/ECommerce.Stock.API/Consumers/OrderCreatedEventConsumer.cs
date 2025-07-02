using ECommerce.SharedEventBus;
using MassTransit;

namespace ECommerce.Stock.API.Consumers
{
    public class OrderCreatedEventConsumer(ILogger<OrderCreatedEventConsumer> logger) : IConsumer<OrderCreatedEvent>
    {
        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            // Sipariş oluşturulduğunda yapılacak işlemler
            // Örneğin, stok güncelleme işlemleri burada yapılabilir.
            /*
             *   2. Stock servisi, siparişteki ürünlerin stokta olup olmadığını kontrol eder.
                 3. Eğer stokta yeterli ürün varsa "stok yeterli" olayı tetiklenir.

             1. Stock servisi, stokta yeterli ürün olmadığını tespit ederse "stok yetersiz" olayı tetiklenir.
             */

            var command = context.Message.Command;
            bool isStockAvailable = checkStockAvailability(command.OrderItems);
            if (isStockAvailable)
            {
                //Stok varsa; sttoğu quantity kadar azalt.
                //StockAvailableEvent tetiklenir.
                // eğer stok problemli ise StockNotAvailableEvent tetiklenir.
                var availableCommand = new StockAvailableCommand(command.OrderId, command.CustomerId, command.CreditCardInfo, command.OrderItems.Sum(item => item.Price * item.Quantity));
                var @event = new StockAvailableEvent(availableCommand);
                await context.Publish(@event);  
                logger.LogInformation($"Stok uygun.... olay fırlatıldı... " );

            }
            else
            {
                // Stok yetersizse, stok yetersiz olayını tetikle
                var notAvailableCommand = new StockNotAvailableCommand(command.OrderId);
                var @event = new StockNotAvailableEvent(notAvailableCommand);
                await context.Publish(@event);
                logger.LogWarning($"Stok yetersiz... olay fırlatıldı... ");
            }
        }

        private bool checkStockAvailability(IEnumerable<OrderItem> orderItems)
        {
           return new Random().Next(0, 2) == 1; // Rastgele stok kontrolü yapılıyor, gerçek stok kontrolü burada yapılmalı.

        }
    }
  
}
