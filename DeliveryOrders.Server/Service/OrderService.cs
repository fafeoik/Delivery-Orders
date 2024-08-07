﻿using Dadata;
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
            var orderModel = await _orderRepository.GetByIdAsync(id);
            return orderModel.Adapt<OrderGetDTO>();
        }

        public async Task AddAsync(OrderPostDTO orderDTO)
        {
            if (orderDTO.CargoPickupDate < DateOnly.FromDateTime(DateTime.Now))
            {
                throw new InvalidOperationException();
            }

            orderDTO.SenderAddressLine = await DadataAddressCleaner.CleanAddress(orderDTO.SenderAddressLine, orderDTO.SenderCity);
            orderDTO.RecipientAddressLine = await DadataAddressCleaner.CleanAddress(orderDTO.RecipientAddressLine, orderDTO.RecipientCity);

            orderDTO.SenderCity = await DadataAddressCleaner.CleanCity(orderDTO.SenderAddressLine, orderDTO.SenderCity);
            orderDTO.RecipientCity = await DadataAddressCleaner.CleanCity(orderDTO.RecipientAddressLine, orderDTO.RecipientCity);

            if(orderDTO.SenderAddressLine == orderDTO.RecipientAddressLine && orderDTO.SenderCity == orderDTO.RecipientCity)
            {
                throw new ArgumentException();
            }

            var orderModel = orderDTO.Adapt<OrderModel>();
            orderModel.OrderCreationDate = DateTime.UtcNow;

            AddressAddDTO recipientAddress = new AddressAddDTO() { AddressLine = orderDTO.RecipientAddressLine, CityName = orderDTO.RecipientCity };
            AddressAddDTO senderAddress = new AddressAddDTO() { AddressLine = orderDTO.SenderAddressLine, CityName = orderDTO.SenderCity };

            orderModel.RecipientAddressId = await _addressService.AddAsync(recipientAddress);
            orderModel.SenderAddressId = await _addressService.AddAsync(senderAddress);
            orderModel.Id = Guid.NewGuid();

            var createdId = await _orderRepository.AddAsync(orderModel);
        }

        public async Task<OrderGetDTO> UpdateAsync(Guid Id, OrderPutDTO orderDTO)
        {
            var orderToUpdate = await _orderRepository.GetByIdAsync(Id);

            if (orderToUpdate != null)
            {
                orderToUpdate.CargoWeight = orderDTO.CargoWeight;
                orderToUpdate.CargoPickupDate = orderDTO.CargoPickupDate;
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
