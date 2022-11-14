using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Test.Services;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyOrderController : ControllerBase
    {
        private readonly IBuyOrderService _buyOrderService;

        public BuyOrderController(IBuyOrderService buyOrderService)
        {
            _buyOrderService = buyOrderService;
        }
        [HttpGet]
        public ActionResult GetAlls()
        {
            return Ok(_buyOrderService.GetAllBuyOrders());
        }
        [HttpGet("{id}")]
        public ActionResult GetProductById(int id)
        {
            return Ok(_buyOrderService.GetOrderById(id));
        }
        [HttpPost]
        public ActionResult Post(BuyOrderModel buyOrderModel)
        {
            _buyOrderService.CreateBuyOrder(buyOrderModel);
            return Ok("Thêm thành công!");
        }
        [HttpDelete]
        public ActionResult Delete(BuyOrderModel buyOrderModel)
        {
            _buyOrderService.DeleteBuyOrder(buyOrderModel);
            return Ok("Xoá thành công!");
        }
        [HttpPut]
        public ActionResult Put(BuyOrderModel buyOrderModel)
        {
            _buyOrderService.UpdateBuyOrder(buyOrderModel);
            return Ok("Update thành công!");
        }
    }
}
