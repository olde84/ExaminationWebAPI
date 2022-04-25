using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreWebAPI_Assignment.Filters;
using StoreWebAPI_Assignment.Models.Order;
using StoreWebAPI_Assignment.Models.Product;
using StoreWebAPI_Assignment.Services;

namespace StoreWebAPI_Assignment.Controllers
{
    [Route("api/[controller]")]
    [UseApiKey]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> CreateOrder(int id, List<ProductModel> cart)
        {
            var order = await _service.CreateOrderAsync(id, cart);
            if (order != null)
            {
                return new OkObjectResult(order);
            }

            return new BadRequestResult();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            return new OkObjectResult(await _service.GetOrdersAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _service.GetOrderAsync(id);
            if (order != null)
            {
                return new OkObjectResult(order);
            }

            return new NotFoundResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int userId, OrderRowUpdate orderRow)
        {
            var orderEntity = await _service.UpdateOrderAsync(userId, orderRow);
            if (orderRow != null)
            {
                return new OkObjectResult(orderRow);
            }

            return new BadRequestResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (await _service.DeleteOrderAsync(id))
            {
                return new OkResult();
            }

            return new BadRequestResult();
        }
    }
}
