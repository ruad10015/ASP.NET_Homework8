using ASP.NET_Homework8.Dtos;
using ASP.NET_Homework8.Entities;
using ASP.NET_Homework8.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP.NET_Homework8.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IEnumerable<ProductDto>> Get()
        {
            var products = await _productService.GetAllAsync();
            var productDtos = products.Select(p => new ProductDto 
            {
                Id = p.Id,
                Name=p.Name,
                Price=p.Price,
                Discount=p.Discount,
            }); 
            return productDtos;
        }

        //Products/GetHigher
        [HttpGet("HigherPrice")]
        public async Task<ProductDto> GetHigherPrice()
        {
            var products = await _productService.GetAllAsync();
            var higherProduct = products.OrderByDescending(p => p.Price).FirstOrDefault();
            var productDto = new ProductDto
            {
                Id = higherProduct!.Id,
                Name = higherProduct.Name,
                Price = higherProduct.Price,
                Discount = higherProduct.Discount,
            };
            return productDto;
        }

        [HttpGet("HigherDiscount")]
        public async Task<ProductDto> GetHigherDiscount()
        {
            var products = await _productService.GetAllAsync();
            var higherProduct = products.OrderByDescending(p => p.Discount).FirstOrDefault();
            var productDto = new ProductDto
            {
                Id = higherProduct!.Id,
                Name = higherProduct.Name,
                Price = higherProduct.Price,
                Discount = higherProduct.Discount,
            };
            return productDto;
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if(product != null) 
            {
                var productDto = new ProductDto 
                { 
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Discount=product.Discount 
                };
                return Ok(productDto);
            }
            return NotFound();
        }


        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductExtendedDto value)
        {
            if(value.Price <= 0) 
            {
                return BadRequest("Minimum Price should be 1");
            }

            if (value.Discount <= 0)
            {
                return BadRequest("Minimum Discount should be 1");
            }

            var product = new Product
            {
                Name = value.Name,
                Price = value.Price,
                Discount = value.Discount,
            };

            await _productService.AddAsync(product);
            return Ok(product);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductExtendedDto value)
        {
            var product = await _productService.GetByIdAsync(id);

            if (value.Price <= 0)
            {
                return BadRequest("Minimum Price should be 1");
            }

            if (value.Discount <= 0)
            {
                return BadRequest("Minimum Discount should be 1");
            }

            if (product != null) 
            {
                product.Name = value.Name;
                product.Price = value.Price;
                product.Discount = value.Discount;
                await _productService.UpdateAsync(product);
                return Ok(product);
            }
            return NotFound();

        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if(product != null) 
            {
                await _productService.DeleteAsync(id);
                return NoContent();
            }
            return NotFound();
        }
    }
}
