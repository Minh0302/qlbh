using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Test.Services;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        public ActionResult GetAlls()
        {
            var results = _orderService.GetAllOrders();
            return Ok(results);
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var result = _orderService.GetOrderById(id);
            return Ok(result);
        }
        [HttpPost]
        public bool Post(OrderModel model)
        {
            return _orderService.CreateOrder(model);
        }
        [HttpPut]
        public bool Put(OrderModel model)
        {
            return _orderService.UpdateOrder(model);
        }
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _orderService.DeleteOrder(id);
        }
    }
}
