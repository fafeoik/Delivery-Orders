using DeliveryOrders.DataAccess.Models;
using DeliveryOrders.Server.DTO;
using Mapster;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace DeliveryOrders.Server.MappingConfigurations
{
    public static class AccountMappingConfiguration
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection services)
        {
            TypeAdapterConfig<OrderModel, OrderGetDTO>
                .NewConfig()
                .Map(dest => dest.SenderCity, src => src.SenderAddress.City.Name)
                .Map(dest => dest.RecipientCity, src => src.RecipientAddress.City.Name)
                .Map(dest => dest.SenderAddressLine, src => src.SenderAddress.AddressLine)
                .Map(dest => dest.RecipientAddressLine, src => src.RecipientAddress.AddressLine)
                .Map(dest => dest.CargoWeight, src => src.CargoWeight)
                .Map(dest => dest.CargoPickupDate, src => src.CargoPickupDate);

            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        }
    }
}
