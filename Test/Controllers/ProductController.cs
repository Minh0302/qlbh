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
            try
            {
                _logger.LogInfo("ProductController : GetAllProducts");
                var products = _productService.GetAllProducts();
                var rs = new Respone()
                {
                    status = 200,
                    message = "Successfully",
                    data = products
                };
                return Ok(rs);
            }catch(Exception ex)
            {
                _logger.LogError("ProductController : GetAllProducts" + ex.Message);
                return BadRequest(ex.Message);
            }
            
        }
        // pagiante product
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
            _logger.LogInfo("ProductController : GetProductById");
            return Ok(_productService.GetProductById(id));
        }
        [HttpPost]
        public IActionResult Post(ProductModel product)
        {
            try
            {
                _logger.LogInfo("ProductController : Post");
                _productService.CreateProduct(product);
                var rs = new Respone()
                {
                    status = 200,
                    message = "Successfully",
                };
                return Ok(rs);
            }
            catch(Exception ex)
            {
                _logger.LogError("ProductController : Post" + ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _logger.LogInfo("ProductController : Post");
                _productService.DeleteProduct(id);
                var rs = new Respone()
                {
                    status = 200,
                    message = "Successfully",
                };
                return Ok(rs);
            }
            catch (Exception ex)
            {
                _logger.LogError("ProductController : Delete" + ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult Put(ProductModel product)
        {
            try
            {
                _logger.LogInfo("ProductController : Put");
                _productService.UpdateProduct(product);
                var rs = new Respone()
                {
                    status = 200,
                    message = "Successfully",
                };
                return Ok(rs);
            }
            catch (Exception ex)
            {
                _logger.LogError("ProductController : Put" + ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
