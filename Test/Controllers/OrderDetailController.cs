using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Test.Services;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }
        [HttpGet]
        public ActionResult GetAlls()
        {
            var results = _orderDetailService.GetAllOrderDetails();
            return Ok(results);
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var result = _orderDetailService.GetOrderDetailById(id);
            return Ok(result);
        }
        [HttpPost]
        public ActionResult Post(OrderDetailModel model)
        {
            _orderDetailService.CreateOrderDetail(model);
            return Ok("Thêm thành công!");
        }
        [HttpPut]
        public ActionResult Put(OrderDetailModel model)
        {
            _orderDetailService.UpdateOrderDetail(model);
            return Ok("Cập nhật thành công!");
        }
        [HttpDelete]
        public ActionResult Delete(OrderDetailModel model)
        {
            _orderDetailService.DeleteOrderDetail(model);
            return Ok("Xóa thành công!");
        }
    }
}
