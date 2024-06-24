using Dadata;
using Dadata.Model;
using DeliveryOrders.DataAccess.Models;
using DeliveryOrders.Repository;
using DeliveryOrders.Server.Dadata;
using DeliveryOrders.Server.DTO;
using DeliveryOrders.Server.Queries;
using DeliveryOrders.Server.Service.Interfaces;
using Mapster;
using System.Linq.Expressions;

namespace DeliveryOrders.Server.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IAddressService _addressService;

        public OrderService(IAddressService addressService, IOrderRepository orderRepository)
        {
            _addressService = addressService;
            _orderRepository = orderRepository;
        }

        public async Task<List<OrderGetDTO>> GetAllAsync(OrderQuery orderQuery)
        {
            var predicates = new List<Expression<Func<OrderModel, bool>>>();

            var orders = await _orderRepository.GetAllAsync(predicates.ToArray());

            return orders.Adapt<List<OrderGetDTO>>();
        }

        public async Task<OrderGetDTO> GetByIdAsync(Guid id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            return order.Adapt<OrderGetDTO>();
        }

        public async Task<bool> AddAsync(OrderPostDTO orderDTO)
        {
            orderDTO.SenderAddressLine = await AddressCleaner.CleanAddress(orderDTO.SenderAddressLine, orderDTO.SenderCity);
            orderDTO.RecipientAddressLine = await AddressCleaner.CleanAddress(orderDTO.RecipientAddressLine, orderDTO.RecipientCity);

            orderDTO.SenderCity = await AddressCleaner.CleanCity(orderDTO.SenderAddressLine, orderDTO.SenderCity);
            orderDTO.RecipientCity = await AddressCleaner.CleanCity(orderDTO.RecipientAddressLine, orderDTO.RecipientCity);

            if(orderDTO.SenderAddressLine == orderDTO.RecipientAddressLine && orderDTO.SenderCity == orderDTO.RecipientCity)
            {
                return false;
            }

            var orderModel = orderDTO.Adapt<OrderModel>();
            orderModel.OrderCreationDate = DateTime.UtcNow;

            AddressAddDTO recipientAddress = new AddressAddDTO() { AddressLine = orderDTO.RecipientAddressLine, CityName = orderDTO.RecipientCity };
            AddressAddDTO senderAddress = new AddressAddDTO() { AddressLine = orderDTO.SenderAddressLine, CityName = orderDTO.SenderCity };

            orderModel.RecipientAddressId = await _addressService.AddAsync(recipientAddress);
            orderModel.SenderAddressId = await _addressService.AddAsync(senderAddress);
            orderModel.Id = Guid.NewGuid();

            var createdId = await _orderRepository.AddAsync(orderModel);

            return true;
        }

        public async Task<OrderGetDTO> UpdateAsync(Guid Id, OrderPutDTO order)
        {
            var orderToUpdate = await _orderRepository.GetByIdAsync(Id);

            if (orderToUpdate != null)
            {
                orderToUpdate.CargoWeight = order.CargoWeight;
                orderToUpdate.CargoPickupDate = order.CargoPickupDate;
                await _orderRepository.Update(orderToUpdate);
            }

            return orderToUpdate.Adapt<OrderGetDTO>();
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            var orderToDelete = await _orderRepository.GetByIdAsync(Id);

            if (orderToDelete == null)
            {
                return false;
            }

            return await _orderRepository.DeleteAsync(orderToDelete);
        }
    }
}
