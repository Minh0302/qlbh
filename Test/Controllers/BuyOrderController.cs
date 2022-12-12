using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Helpers;
using Test.Models;
using Test.Paging;
using Test.Services;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyOrderController : ControllerBase
    {
        private readonly IBuyOrderService _buyOrderService;
        private readonly ILoggerManager _logger;

        public BuyOrderController(IBuyOrderService buyOrderService, ILoggerManager logger)
        {
            _buyOrderService = buyOrderService;
            _logger = logger;
        }
        [HttpGet]
        //public ActionResult GetAlls()
        //{
        //    _logger.LogInfo("BuyOrderController : GetAlls");
        //    return Ok(_buyOrderService.GetAllBuyOrders());
        //}
        public ActionResult GetAlls([FromQuery] PagingParameters paging)
        {
            var rs = _buyOrderService.PaginateBuyOrders(paging);
            return Ok(new
            {
                currentPage = rs.CurrentPage,
                totalPage = rs.TotalPages,
                data = rs.data
            });
        }
        [HttpGet("{id}")]
        public ActionResult GetProductById(int id)
        {
            _logger.LogInfo("BuyOrderController : GetProductById");
            return Ok(_buyOrderService.GetOrderById(id));
        }
        [HttpPost]
        public bool Post(BuyOrderModel buyOrderModel)
        {
            _logger.LogInfo("BuyOrderController : Post");
            return _buyOrderService.CreateBuyOrder(buyOrderModel);
        }
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            _logger.LogInfo("BuyOrderController : Delete");
            return _buyOrderService.DeleteBuyOrder(id);
        }
        [HttpPut]
        public bool Put(BuyOrderModel buyOrderModel)
        {
            _logger.LogInfo("BuyOrderController : Put");
            return _buyOrderService.UpdateBuyOrder(buyOrderModel);
        }
    }
}
