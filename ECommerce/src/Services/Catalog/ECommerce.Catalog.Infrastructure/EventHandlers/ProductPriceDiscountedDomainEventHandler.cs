using ECommerce.Catalog.Domain.Events;
using ECommerce.SharedEventBus;
using MassTransit;
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
        private readonly IPublishEndpoint _publishEndpoint;

        public ProductPriceDiscountedDomainEventHandler(ILogger<ProductPriceDiscountedDomainEventHandler> logger, IPublishEndpoint publishEndpoint)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        }
        public async Task Handle(ProductPriceDiscountedDomainEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{notification.ProducId} id'li ürünün eski fiyatı, {notification.OldPrice}, yeni fiyatı ise {notification.NewPrice} olarak güncellendi");

            //ürün fiyatı indirim yapıldığında yapılacak işlemler burada yer alabilir.
            ProductPriceDiscountedEvent @event = new ProductPriceDiscountedEvent(notification.ProducId,  notification.NewPrice,notification.OldPrice);

           await  _publishEndpoint.Publish(@event, cancellationToken);


         
        }
    }
}
