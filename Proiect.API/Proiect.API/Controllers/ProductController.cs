using Microsoft.AspNetCore.Mvc;
using Proiect.Core.Services;
using Proiect.Database.Dtos.Request;
using Proiect.Database.Dtos.Response;

namespace Proiect.Api.Controllers
{
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddProduct([FromBody] AddProductRequest payload)
        {
            _productService.AddProduct(payload);
            return Ok("Product has been successfully added");
        }

        [HttpGet]
        [Route("get")]
        public IActionResult GetProducts([FromQuery] GetProductRequest products)
        {
            var result = _productService.GetProducts(products);
            return Ok(result);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateProduct([FromBody] UpdateProductRequest payload)
        {
            _productService.UpdateProduct(payload);
            return Ok("Product has been successfully updated");
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult DeleteProduct([FromBody] DeleteProductRequest payload)
        {
            _productService.DeleteProduct(payload);
            return Ok("Product has been successfully deleted");
        }
    }
}
