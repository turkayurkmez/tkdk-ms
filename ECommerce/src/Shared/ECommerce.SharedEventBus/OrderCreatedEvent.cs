using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.SharedEventBus
{
    public record OrderCreatedEvent(OrderCreateCommand Command) : IntegrationEvent;

    public record OrderCreateCommand(int OrderId, string CustomerId, string CreditCardInfo, IEnumerable<OrderItem> OrderItems );

    public record OrderItem(string ProductId, int Quantity, decimal Price); 


}
