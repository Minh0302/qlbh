using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Test.Helpers;
using Test.Models;
using Test.Services;

namespace Test.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILoggerManager _logger;

        public ProductController(IProductService productService, ILoggerManager logger)
        {
            _productService = productService;
            _logger = logger;
        }
        [HttpGet]
        public ActionResult GetAllProducts()
        {
            _logger.LogInfo("ProductController : GetAllProducts");
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
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
             _productService.DeleteProduct(id);
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
