using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data.SqlTypes;
using Test.Data;
using Test.Entities;
using Test.Helpers;
using Test.Models;
using Test.Paging;
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
        //public ActionResult GetAllProductsPaging([FromQuery] PagingParameters paging)
        //{
        //    var rs = _productService.PaginateProducts(paging);
        //    return Ok(new
        //    {
        //        currentPage = rs.CurrentPage,
        //        totalPage = rs.TotalPages,
        //        data = rs.data
        //    });
        //}
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
