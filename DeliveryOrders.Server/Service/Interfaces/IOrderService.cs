using DeliveryOrders.Server.DTO;
using DeliveryOrders.Server.Queries;

namespace DeliveryOrders.Server.Service.Interfaces
{
    public interface IOrderService
    {
        Task<OrderGetDTO> GetByIdAsync(Guid id);
        Task<List<OrderGetDTO>> GetAllAsync(OrderQuery orderQuery);
        Task AddAsync(OrderPostDTO order);
        Task<OrderGetDTO> UpdateAsync(Guid Id, OrderPutDTO order);
        Task<bool> DeleteAsync(Guid Id);
    }
}
