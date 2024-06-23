using DeliveryOrders.Server.DTO;
using DeliveryOrders.Server.Queries;

namespace DeliveryOrders.Server.Service.Interfaces
{
    public interface IAddressService
    {
        Task<Guid> AddAsync(AddressAddDTO address);
    }
}
