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
        public bool Post(ProductModel product)
        {
            return _productService.CreateProduct(product);
        }
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
             return _productService.DeleteProduct(id);
        }
        [HttpPut]
        public bool Put(ProductModel product)
        {
            return _productService.UpdateProduct(product);
        }
    }
}
