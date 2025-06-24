using ECommerce.SharedLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Domain.Events
{
    public class ProductPriceDiscountedDomainEvent : DomainEvent
    {
        public Guid ProducId { get; private set; }
        public decimal OldPrice { get; private set; }
        public decimal NewPrice { get; private set; }

        public ProductPriceDiscountedDomainEvent(Guid producId, decimal oldPrice, decimal newPrice)
        {
            ProducId = producId;
            OldPrice = oldPrice;
            NewPrice = newPrice;
        }
    }
}
