using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.SharedEventBus
{
    public record PaymentSuccessEvent(int OrderId) : IntegrationEvent;
    public record PaymentFailedEvent(int OrderId, string Reason) : IntegrationEvent;
}
