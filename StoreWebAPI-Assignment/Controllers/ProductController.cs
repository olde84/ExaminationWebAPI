using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreWebAPI_Assignment.Filters;
using StoreWebAPI_Assignment.Models.Product;
using StoreWebAPI_Assignment.Services;

namespace StoreWebAPI_Assignment.Controllers
{
    [Route("api/[controller]")]
    [UseApiKey]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductRequest request)
        {
            var product = await _service.CreateProductAsync(request);
            if (product != null)
            {
                return new OkObjectResult(product);
            }

            return new BadRequestResult();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return new OkObjectResult(await _service.GetProductsAsync());
        }

        [HttpGet("{articleNr}")]
        public async Task<IActionResult> GetProduct(int articleNr)
        {
            var product = await _service.GetProductAsync(articleNr);
            if (product != null)
            {
                return new OkObjectResult(product);
            }

            return new NotFoundResult();
        }

        [HttpPut("{articleNr}")]
        public async Task<IActionResult> UpdateUser(int articleNr, ProductRequest request)
        {
            var product = await _service.UpdateProductAsync(articleNr, request);
            if (product != null)
            {
                return new OkObjectResult(product);
            }

            return new BadRequestResult();
        }

        [HttpDelete("{articleNr}")]
        public async Task<IActionResult> DeleteUser(int articleNr)
        {
            if (await _service.DeleteProductAsync(articleNr))
            {
                return new OkResult();
            }

            return new BadRequestResult();
        }
    }
}
