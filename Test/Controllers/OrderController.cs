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
        public ActionResult Post(OrderModel model)
        {
            _orderService.CreateOrder(model);
            return Ok("Thêm thành công!");
        }
        [HttpPut]
        public ActionResult Put(OrderModel model)
        {
            _orderService.UpdateOrder(model);
            return Ok("Cập nhật thành công!");
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _orderService.DeleteOrder(id);
            return Ok("Xóa thành công!");
        }
    }
}
