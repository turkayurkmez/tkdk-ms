using ECommerce.Catalog.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Infrastructure.EventHandlers
{
    public class ProductPriceDiscountedDomainEventHandler : INotificationHandler<ProductPriceDiscountedDomainEvent>
    {
        private readonly ILogger<ProductPriceDiscountedDomainEventHandler> _logger;

        public ProductPriceDiscountedDomainEventHandler(ILogger<ProductPriceDiscountedDomainEventHandler> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public Task Handle(ProductPriceDiscountedDomainEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{notification.ProducId} id'li ürünün eski fiyatı, {notification.OldPrice}, yeni fiyatı ise {notification.NewPrice} olarak güncellendi");

            return Task.CompletedTask;
        }
    }
}
