using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.SharedEventBus
{
    public record StockAvailableEvent(StockAvailableCommand Command) : IntegrationEvent;
    public record StockAvailableCommand(int OrderId, string CustomerId, string CreditCardInfo, decimal? TotalPrice);

    public record StockNotAvailableEvent(StockNotAvailableCommand Command) : IntegrationEvent;
    public record StockNotAvailableCommand(int OrderId); // Stok yetersiz olduğunda kullanılacak komut. Bu komut, stok yetersiz olduğunda tetiklenir ve gerekli bilgileri içerir.
}
