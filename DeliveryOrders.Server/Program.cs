using DeliveryOrders.DataAccess;
using DeliveryOrders.Repository.Implementations;
using DeliveryOrders.Repository;
using DeliveryOrders.Server.Service.Interfaces;
using DeliveryOrders.Server.Service;
using Microsoft.EntityFrameworkCore;
using DeliveryOrders.Server.MappingConfigurations;
using DeliveryOrders.Server.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.RegisterMapsterConfiguration();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(DataContext)));
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:8080");
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
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

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseCors();

app.UseHttpsRedirection();

app.MapControllers();

SeedData.EnsurePopulated(app);

app.Run();
