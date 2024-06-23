using DeliveryOrders.Server.DTO;

namespace DeliveryOrders.Server.Service.Interfaces
{
    public interface ICityService
    {
        Task<Guid> AddAsync(CityAddDTO city);
    }
}
