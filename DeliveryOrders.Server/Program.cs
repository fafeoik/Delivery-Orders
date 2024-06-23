using DeliveryOrders.DataAccess;
using DeliveryOrders.Repository.Implementations;
using DeliveryOrders.Repository;
using DeliveryOrders.Server.Service.Interfaces;
using DeliveryOrders.Server.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(DataContext)));
});

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();

builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IAddressService, AddressService>();
builder.Services.AddTransient<ICityService, CityService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
