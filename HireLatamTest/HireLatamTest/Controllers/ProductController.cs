using HireLatamTest.Request;
using HireLatamTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireLatamTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductRequest productDto)
        {
            if (productDto == null || string.IsNullOrWhiteSpace(productDto.Name) || productDto.Price < 0)
            {
                return BadRequest("Invalid product data.");
            }

            var product = await _productService.CreateAsync(productDto.Name, productDto.Price);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid product ID.");
            }

            var result = await _productService.DeleteAsync(id);
            if (!result)
            {
                return NotFound("Product not found.");
            }

            return NoContent();
        }
    }
}
