﻿using DeliveryOrders.Server.DTO;
using DeliveryOrders.Server.Queries;
using DeliveryOrders.Server.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryOrders.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<List<OrderGetDTO>>> GetAll([FromQuery] OrderQuery orderQuery) // Если нам понадобится добавить фильтрацию или поиск, мы можем добавить нужные свойства в OrderQuery и сделать фильтрацию по ним
        {
            try
            {
                var accounts = await _orderService.GetAllAsync(orderQuery);

                return !accounts.Any()
                ? NotFound()
                : Ok(accounts);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a database failure");
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<OrderGetDTO>> Get(Guid id)
        {
            try
            {
                var accountDTO = await _orderService.GetByIdAsync(id);

                return accountDTO == null
                ? NotFound()
                : Ok(accountDTO);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a database failure");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrderPostDTO modelDTO)
        {
            try
            {
                return await _orderService.AddAsync(modelDTO) ? Ok()
                    : StatusCode(StatusCodes.Status400BadRequest, "Адреса и города получателя и отправителя не должны совпадать");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a database failure");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OrderGetDTO>> Put(Guid id, OrderPutDTO orderDTO)
        {
            try
            {
                var orderToUpdate = await _orderService.UpdateAsync(id, orderDTO);

                if (orderToUpdate != null)
                {
                    return orderToUpdate;
                }
                else
                {
                    return NotFound($"Can't find order with Id {id}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"There was a database failure: {ex.Message}");
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                return await _orderService.DeleteAsync(Id) ? Ok()
                : NotFound($"Can't find order with Id {Id}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"There was a database failure: {ex.Message}");
            }
        }
    }
}
