using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Helpers;
using Test.Models;
using Test.Services;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILoggerManager _logger;

        public OrderController(IOrderService orderService, ILoggerManager logger)
        {
            _orderService = orderService;
            _logger = logger;
        }
        [HttpGet]
        public ActionResult GetAlls()
        {
            _logger.LogInfo("OrderController : GetAlls");
            var results = _orderService.GetAllOrders();
            return Ok(results);
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            _logger.LogInfo("OrderController : GetById");
            var result = _orderService.GetOrderById(id);
            return Ok(result);
        }
        [HttpPost]
        public bool Post(OrderModel model)
        {
            _logger.LogInfo("OrderController : Post");
            return _orderService.CreateOrder(model);
        }
        [HttpPut]
        public bool Put(OrderModel model)
        {
            _logger.LogInfo("OrderController : Put");
            return _orderService.UpdateOrder(model);
        }
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            _logger.LogInfo("OrderController : Delete");
            return _orderService.DeleteOrder(id);
        }
    }
}
