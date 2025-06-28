using ECommerce.Order.API.Consumers;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(config =>
{
    /*
     * Problem: 
     * Alıcı (Consumer) gelen mesajı alamazsa; nasıl bir çözüm uygulanabilir?
     *    1. Retry mekanizması: Alıcı mesajı alırken hata alırsa, belirli bir süre sonra tekrar denemek için yapılandırılabilir.
     */

    config.AddConsumer<OrderProductPriceDiscountedConsumer>(c =>
    {
        c.UseMessageRetry(r =>
        {
            r.Intervals(TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(15));
            //r.Exponential(5,TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(60),TimeSpan.FromSeconds(1));
            r.Handle<TimeoutException>();
            //r.ConnectRetryObserver(new RetryObserver()); // Retry işlemi sırasında loglama yapabilmek için
        }
        ); // 3 kez dene, her seferinde 5 saniye bekle

        c.UseCircuitBreaker(cb =>
        {
            cb.TrackingPeriod = TimeSpan.FromMinutes(1); // 1 dakika boyunca hata sayısını takip et
            cb.TripThreshold = 5; // 5 kez hata alırsa devre kesilsin
            cb.ActiveThreshold = 3; // 3 kez üst üste hata alırsa devre kesilsin
            cb.ResetInterval = TimeSpan.FromMinutes(1); // Devre kesildikten sonra 1 dakika bekle
        });
    });
    config.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        cfg.ReceiveEndpoint("order-service", e =>
        {
            e.ConfigureConsumer<OrderProductPriceDiscountedConsumer>(context);
        });
    });
});

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
