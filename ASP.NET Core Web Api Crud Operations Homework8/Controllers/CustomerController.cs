using ASP.NET_Homework8.Dtos;
using ASP.NET_Homework8.Entities;
using ASP.NET_Homework8.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP.NET_Homework8.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService? _customerService;

        public CustomerController(ICustomerService? customerService)
        {
            _customerService = customerService;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<IEnumerable<CustomerDto>> Get()
        {
            var customers = await _customerService!.GetAllAsync();
            var customerDtos = customers.Select(c => new CustomerDto
            {
                Id = c.Id,
                Name = c.Name,
                Surname = c.Surname,
            });
            return customerDtos;
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await _customerService!.GetByIdAsync(id);
            if (customer != null)
            {
                var customerDto = new CustomerDto
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Surname = customer.Surname,
                };
                return Ok(customerDto);
            }
            return NotFound();
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerExtendedDto value)
        {
            var customer = new Customer
            {
                Name = value.Name,
                Surname = value.Surname,
            };
            await _customerService!.AddAsync(customer);
            return Ok(customer);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CustomerExtendedDto value)
        {
            var customer = await _customerService!.GetByIdAsync(id);
            if (customer != null) 
            {
                customer.Name = value.Name;
                customer.Surname = value.Surname;
                
                await _customerService.UpdateAsync(customer);
                return Ok(customer);
            }
            return NotFound();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        { 
            var customer = await _customerService!.GetByIdAsync(id);
            if(customer != null) 
            {
                await _customerService.DeleteAsync(id);
                return NoContent();
            }
            return NotFound();
        }
    }
}
