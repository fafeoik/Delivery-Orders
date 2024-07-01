using DeliveryOrders.DataAccess;
using DeliveryOrders.DataAccess.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryOrders.DataAccess
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<DataContext>();

            if (!context.Cities.Any())
            {
                var cities = new List<CityModel>()
                {
                     new CityModel { Id = Guid.NewGuid(), Name = "Новосибирск" },
                     new CityModel { Id = Guid.NewGuid(), Name = "Москва" },
                     new CityModel { Id = Guid.NewGuid(), Name = "Санкт-Петербург" },
                     new CityModel { Id = Guid.NewGuid(), Name = "Кемерово" }
                };

                context.Cities.AddRange(cities);
                context.SaveChanges();
            }

            if (!context.Addresses.Any())
            {
                var addresses = new List<AddressModel>()
                {
                     new AddressModel
                     {
                         Id = Guid.NewGuid(),
                         AddressLine = "Ул. Ленина, 10",
                         CityId = context.Cities.First(c => c.Name == "Новосибирск").Id,
                         City = context.Cities.First(c => c.Name == "Новосибирск")
                     },
                     new AddressModel
                     {
                         Id = Guid.NewGuid(),
                         AddressLine = "Ул. Юбилейная, 22",
                         CityId = context.Cities.First(c => c.Name == "Москва").Id,
                         City = context.Cities.First(c => c.Name == "Москва")
                     },
                     new AddressModel
                     {
                         Id = Guid.NewGuid(),
                         AddressLine = "Ул. Советская, 14",
                         CityId = context.Cities.First(c => c.Name == "Санкт-Петербург").Id,
                         City = context.Cities.First(c => c.Name == "Санкт-Петербург")
                     },
                     new AddressModel
                     {
                         Id = Guid.NewGuid(),
                         AddressLine = "Пер. Толстого, 2",
                         CityId = context.Cities.First(c => c.Name == "Москва").Id,
                         City = context.Cities.First(c => c.Name == "Москва")
                     },
                     new AddressModel
                     {
                         Id = Guid.NewGuid(),
                         AddressLine = "Ул. Гагарина, 36",
                         CityId = context.Cities.First(c => c.Name == "Кемерово").Id,
                         City = context.Cities.First(c => c.Name == "Кемерово")
                     },
                     new AddressModel
                     {
                         Id = Guid.NewGuid(),
                         AddressLine = "Ул. Суворова, 18",
                         CityId = context.Cities.First(c => c.Name == "Новосибирск").Id,
                         City = context.Cities.First(c => c.Name == "Новосибирск")
                     }

                };

                context.Addresses.AddRange(addresses);
                context.SaveChanges();
            }

            if (!context.Orders.Any())
            {
                var orders = new List<OrderModel>()
                {
                    new OrderModel
                    {
                        Id = Guid.NewGuid(),
                        RecipientAddressId = context.Addresses.First(a => a.AddressLine == "Ул. Ленина, 10").Id,
                        RecipientAddress = context.Addresses.First(a => a.AddressLine == "Ул. Ленина, 10"),
                        SenderAddressId = context.Addresses.First(a => a.AddressLine == "Ул. Юбилейная, 22").Id,
                        SenderAddress = context.Addresses.First(a => a.AddressLine == "Ул. Юбилейная, 22"),
                        CargoWeight = 35,
                        CargoPickupDate = new DateOnly(2025, 12, 31),
                        OrderCreationDate = DateTimeOffset.UtcNow
                    },
                     new OrderModel
                    {
                        Id = Guid.NewGuid(),
                        RecipientAddressId = context.Addresses.First(a => a.AddressLine == "Ул. Советская, 14").Id,
                        RecipientAddress = context.Addresses.First(a => a.AddressLine == "Ул. Советская, 14"),
                        SenderAddressId = context.Addresses.First(a => a.AddressLine == "Пер. Толстого, 2").Id,
                        SenderAddress = context.Addresses.First(a => a.AddressLine == "Пер. Толстого, 2"),
                        CargoWeight = 5,
                        CargoPickupDate = new DateOnly(2024, 07, 5),
                        OrderCreationDate = DateTimeOffset.UtcNow
                    },
                      new OrderModel
                    {
                        Id = Guid.NewGuid(),
                        RecipientAddressId = context.Addresses.First(a => a.AddressLine == "Ул. Гагарина, 36").Id,
                        RecipientAddress = context.Addresses.First(a => a.AddressLine == "Ул. Гагарина, 36"),
                        SenderAddressId = context.Addresses.First(a => a.AddressLine == "Ул. Суворова, 18").Id,
                        SenderAddress = context.Addresses.First(a => a.AddressLine == "Ул. Суворова, 18"),
                        CargoWeight = 150,
                        CargoPickupDate = new DateOnly(2024, 09, 25),
                        OrderCreationDate = DateTimeOffset.UtcNow
                    }
                };

                context.Orders.AddRange(orders);
                context.SaveChanges();
            }
        }
    }
}