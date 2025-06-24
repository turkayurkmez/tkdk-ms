using ECommerce.Catalog.Domain.Events;
using ECommerce.SharedLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Domain.Aggregates
{
    public  class Product : AggregateRoot<Guid>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int? Stock { get; set; }
        public int? CategoryId {  get; private set; }
        public Category Category { get; private set; }

        public string? ImageUrl { get; private set; } = "noimage.png";

        public Product()
        {
                
        }

        public Product(string name, string description, decimal price, int? stock=default, int? categoryId=null )
        {
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            CategoryId = categoryId;

        }

        public void ApplyDiscount(decimal discountRate)
        {
            var oldPrice = Price;
            Price = Price * (1 - discountRate);
            AddDomainEvent(new ProductPriceDiscountedDomainEvent(Id, oldPrice, Price));

        }

    }
}
