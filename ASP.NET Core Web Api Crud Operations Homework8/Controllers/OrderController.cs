using ASP.NET_Homework8.Dtos;
using ASP.NET_Homework8.Entities;
using ASP.NET_Homework8.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP.NET_Homework8.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService? _orderService;
        private readonly ICustomerService? _customerService;
        private readonly IProductService? _productService;

        public OrderController(IOrderService? orderService, ICustomerService? customerService, IProductService? productService)
        {
            _orderService = orderService;
            _customerService = customerService;
            _productService = productService;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public async Task<IEnumerable<OrderDto>> Get()
        {
            var orders = await _orderService!.GetAllAsync();
            var orderDtos = orders.Select(o => new OrderDto
            {
                Id = o.Id,
                OrderDate = o.OrderDate,
                CustomerId = o.CustomerId,
                ProductId = o.ProductId,
            });
            return orderDtos;
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var order = await _orderService!.GetByIdAsync(id);
            if (order != null)
            {
                var orderDto = new OrderDto
                {
                    Id = order.Id,
                    OrderDate = order.OrderDate,
                    CustomerId = order.CustomerId,
                    ProductId = order.ProductId,
                };
                return Ok(orderDto);
            }
            return NotFound();
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderExtendedDto value)
        {
            var product = await _productService!.GetByIdAsync(value.ProductId);
            var customer = await _customerService!.GetByIdAsync(value.CustomerId);
            if(product == null) 
            {
                return NotFound("Not Found Product ");
            }
            else if(customer == null) 
            {
                return NotFound("Not Found Customer ");
            }

            var order = new Order
            {
                ProductId = value.ProductId,
                CustomerId = value.CustomerId,
                OrderDate = value.OrderDate,
            };
            await _orderService!.AddAsync(order);
            return Ok(order);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] OrderExtendedDto value)
        {
            var order = await _orderService!.GetByIdAsync(id);
            if (order != null)
            {
                var product = await _productService!.GetByIdAsync(value.ProductId);
                var customer = await _customerService!.GetByIdAsync(value.CustomerId);
                if (product == null)
                {
                    return NotFound("Not Found Product ");
                }
                else if (customer == null)
                {
                    return NotFound("Not Found Customer ");
                }

                order.ProductId = value.ProductId;
                order.CustomerId = value.CustomerId;
                order.OrderDate = value.OrderDate;

                await _orderService!.UpdateAsync(order);
                return Ok(order);
            }
            return NotFound();
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var order = await _orderService!.GetByIdAsync(id);
            if (order != null) 
            {
                await _orderService.DeleteAsync(id);
                return NoContent();
            }
            return NotFound();
        }
    }
}
