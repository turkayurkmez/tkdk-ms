
using ECommerce.Catalog.Apllication.Features.Products.Commands.DiscountProductPrice;
using ECommerce.Catalog.Domain.Repositories;
using ECommerce.Catalog.Infrastructure.EventHandlers;
using ECommerce.Catalog.Infrastructure.Persistence;
using ECommerce.Catalog.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using ECommerce.Catalog.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("CatalogConnection");
builder.Services.AddInfrastructure(connectionString);
builder.Services.AddApplication();

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

