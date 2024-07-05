using DeliveryOrders.Server.DTO;
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
            var accounts = await _orderService.GetAllAsync(orderQuery);

            return !accounts.Any()
            ? throw new Exception()
            : Ok(accounts);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<OrderGetDTO>> Get(Guid id)
        {
            var accountDTO = await _orderService.GetByIdAsync(id);

            return accountDTO == null
            ? throw new KeyNotFoundException()
            : Ok(accountDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrderPostDTO modelDTO)
        {
            await _orderService.AddAsync(modelDTO);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OrderGetDTO>> Put(Guid id, OrderPutDTO orderDTO)
        {
            var orderToUpdate = await _orderService.UpdateAsync(id, orderDTO);

            if (orderToUpdate != null)
            {
                return orderToUpdate;
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
                return await _orderService.DeleteAsync(Id) ? Ok()
                : throw new KeyNotFoundException();
        }
    }
}
