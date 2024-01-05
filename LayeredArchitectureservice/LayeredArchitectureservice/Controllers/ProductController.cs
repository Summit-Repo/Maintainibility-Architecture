using Application;
using AutoMapper;
using DataAccess.Domain;
using LayeredArchitectureservice.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LayeredArchitectureservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductOperationRule _productOperationRule;
        private readonly IMapper _mapper;

        public ProductController(IMapper mapper, IConfiguration configuration)
        {

            _productOperationRule = new ProductOperationRule(configuration);
            _mapper = mapper;

        }


        [HttpPost]
        public IActionResult AddProduct([FromBody] ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            var status = _productOperationRule.AddProductRule(product);

            return Ok(new { Status = status });
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromBody] ProductDto productUpdateDto)
        {
            var existingProduct = _productOperationRule.GetProductById(productUpdateDto.ProductId);

            if (existingProduct == null) return NotFound(new { Status = "Product not found." });


            var updatedProduct = _mapper.Map(productUpdateDto, existingProduct);
            var status = _productOperationRule.UpdateProductRule(updatedProduct);

            return Ok(new { Status = status });
        }

        [HttpDelete("{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            var status = _productOperationRule.DeleteProductRule(productId);
            return Ok(new { Status = status });
        }

        [HttpGet("{productId}")]
        public IActionResult GetProductById(int productId)
        {
            var product = _productOperationRule.GetProductById(productId);
            var productDto = _mapper.Map<ProductDto>(product);

            return Ok(productDto);
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _productOperationRule.GetAllProducts();
            var productDto = _mapper.Map<IEnumerable<ProductDto>>(products);

            return Ok(productDto);
        }
    }

}
