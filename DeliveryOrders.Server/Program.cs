using DeliveryOrders.DataAccess;
using DeliveryOrders.Repository.Implementations;
using DeliveryOrders.Repository;
using DeliveryOrders.Server.Service.Interfaces;
using DeliveryOrders.Server.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<DataContext>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();

builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IAddressService, AddressService>();
builder.Services.AddTransient<ICityService, CityService>();

var app = builder.Build();

using var scope = app.Services.CreateScope();
await using var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
await dbContext.Database.EnsureCreatedAsync();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
