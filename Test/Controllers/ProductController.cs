using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Test.Models;
using Test.Services;

namespace Test.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        //private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public ActionResult GetAllProducts()
        {
            return Ok(_productService.GetAllProducts());
        }
        [HttpGet("{id}")]
        public ActionResult GetProductById(int id)
        {
            return Ok(_productService.GetProductById(id));
        }
        [HttpPost]
        public ActionResult Post(ProductModel product)
        {
            _productService.CreateProduct(product);
            return Ok("Thêm thành công!");
        }
        [HttpDelete]
        public ActionResult Delete(ProductModel product)
        {
            _productService.DeleteProduct(product);
            return Ok("Xoá thành công!");
        }
        [HttpPut]
        public ActionResult Put(ProductModel product)
        {
            _productService.UpdateProduct(product);
            return Ok("Update thành công!");
        }
    }
}
