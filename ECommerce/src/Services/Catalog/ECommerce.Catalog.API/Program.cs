
using ECommerce.Catalog.Apllication.Features.Products.Commands.DiscountProductPrice;
using ECommerce.Catalog.Domain.Repositories;
using ECommerce.Catalog.Infrastructure.EventHandlers;
using ECommerce.Catalog.Infrastructure.Persistence;
using ECommerce.Catalog.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using ECommerce.Catalog.Infrastructure.Extensions;
using ECommerce.Catalog.Infrastructure;
using MassTransit;
using ECommerce.SharedEventBus;
using MassTransit.Transports.Fabric;
using RabbitMQ.Client;
using ExchangeType = RabbitMQ.Client.ExchangeType;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("CatalogConnection");
builder.Services.AddInfrastructure(connectionString);
builder.Services.AddApplication();


//Problem: Ya yayıncı, RabbitMQ'ya mesaj gönderemezse?
//Çözüm 1: RabbitMQ'ya mesaj gönderilemediğinde, mesajı tekrar denemek için bir retry mekanizması eklenebilir. Bu, MassTransit'in retry özellikleri kullanılarak yapılabilir.
//Çözüm 2: Göndeilmeyen mesajı db'ye kaydet.... Bu pattern ise Outbox Pattern olarak bilinir. Bu pattern, mesajların kaydedilmesi ve daha sonra tekrar denenmesi için kullanılır. Bu, genellikle bir Outbox tablosu oluşturarak yapılır ve mesajlar bu tabloya kaydedilir. Daha sonra, bir arka plan işleyici bu tablodan mesajları alır ve RabbitMQ'ya gönderir.


builder.Services.AddMassTransit(config =>
{
    config.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
      cfg.Publish<ProductPriceDiscountedEvent>(tc=>tc.ExchangeType = ExchangeType.Fanout);
    });
});

//aşağıdaki injectionlar yerine extension metodlar kullanıldı:

//builder.Services.AddDbContext<CatalogDbContext>(option=> option.UseSqlServer(connectionString));
//builder.Services.AddMediatR(config =>
//{
//    config.RegisterServicesFromAssemblyContaining<DiscountProductPriceCommandRequest>();
//    config.RegisterServicesFromAssemblyContaining<ProductPriceDiscountedDomainEventHandler>();
//});

//builder.Services.AddScoped<IProductRepository, ProductRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();


app.MapControllers();

app.Run();

