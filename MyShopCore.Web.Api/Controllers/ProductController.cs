using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShopCore.Web.Api.Models.Products;
using MyShopCore.Web.Api.Services.Foundations.Products;

namespace MyShopCore.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet]

        public IActionResult GetAllProducts()
        {
            var products = this.productService.RetrieveAllProducts().ToList();
            return Ok(products);
        }

        [HttpGet("{id}", Name = "GetSingleProduct")]

        public async ValueTask<IActionResult> GetProductAsync(Guid id)
        {
            var product = await this.productService.RetrieveProductByIdAsync(id);

            if (product is null)
                return NotFound();  

            return Ok(product);
        }

        [HttpPost]

        public async ValueTask<IActionResult> PostProduct([FromBody] Product product)
        { 
            var newProduct = await this.productService.AddProductAsync(product);

            return Created("GetSingleProduct", newProduct);
        }

        [HttpPut]

        public async ValueTask<IActionResult> PutProduct([FromBody] Product product)
        {
            var currentProduct = await this.productService.RetrieveProductByIdAsync(product.Id);

            if (currentProduct is null)
                return NotFound();

            var updateProduct = await this.productService.ModifyProductAsync(product);
            return Ok(updateProduct);
        }

        [HttpDelete]

        public async ValueTask<IActionResult> DeleteProduct(Guid id)
        {
            var currentProduct = await this.productService.RetrieveProductByIdAsync(id);

            if (currentProduct is null)
                return NotFound();

            var deleteProduct = await this.productService.RemoveProductAsync(currentProduct);
            return NoContent();
        }
    }
}
