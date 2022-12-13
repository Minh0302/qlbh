using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Helpers;
using Test.Models;
using Test.Services;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyOrderDetailController : ControllerBase
    {
        private readonly IBuyOrderDetailService _buyOrderDetailModel;
        private readonly ILoggerManager _logger;

        public BuyOrderDetailController(IBuyOrderDetailService buyOrderDetailModel, ILoggerManager logger)
        {
            _buyOrderDetailModel = buyOrderDetailModel;
            _logger = logger;
        }
        [HttpGet]
        public ActionResult GetAlls()
        {
            var getAlls = _buyOrderDetailModel.GetAllBuyOrderDetails();
            return Ok(getAlls);
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var result = _buyOrderDetailModel.GetBuyOrderDetailsById(id);
            return Ok(result);
        }
        [HttpPost]
        public ActionResult Post(BuyOrderDetailModel model)
        {
            _buyOrderDetailModel.CreateBuyOrderDetail(model);
            return Ok("Thêm thành công!");
        }
        [HttpPut]
        public ActionResult Put(BuyOrderDetailModel model)
        {
            _buyOrderDetailModel.UpdateBuyOrderDetail(model);
            return Ok("Cập nhật thành công!");
        }
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            _logger.LogInfo("BuyOrderDetailController : Delete");
            return _buyOrderDetailModel.DeleteBuyOrderDetail(id);
        }
    }
}
