using ECommerce.Basket.API.Consumers;
using ECommerce.Basket.API.Protos;
using ECommerce.Basket.API.Services;
using ECommerce.SharedEventBus;
using MassTransit;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();

builder.Services.AddMassTransit(config =>
{

    config.AddConsumer<BasketProductPriceDiscountedConsumer>();
    config.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        cfg.ReceiveEndpoint("basket-service", e =>
        {
            e.ConfigureConsumer<BasketProductPriceDiscountedConsumer>(context);
        });
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGrpcService<CustomBasketService>();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
/*
 * docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3.10-management
 */