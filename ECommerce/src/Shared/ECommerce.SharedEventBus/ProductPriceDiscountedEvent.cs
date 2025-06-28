using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.SharedEventBus
{
    public record ProductPriceDiscountedEvent(Guid ProductId, decimal NewPrice, decimal OldPrice): IntegrationEvent; 
    
}
