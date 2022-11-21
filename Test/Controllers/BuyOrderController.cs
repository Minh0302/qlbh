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
        public bool Post(BuyOrderModel buyOrderModel)
        {
            return _buyOrderService.CreateBuyOrder(buyOrderModel);
        }
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _buyOrderService.DeleteBuyOrder(id);
        }
        [HttpPut]
        public bool Put(BuyOrderModel buyOrderModel)
        {
            return _buyOrderService.UpdateBuyOrder(buyOrderModel);
        }
    }
}
