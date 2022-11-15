using Test.Entities;
using Test.Models;

namespace Test.Services
{
    public interface IBuyOrderDetailService
    {
        public IEnumerable<BuyOrderDetail> GetAllBuyOrderDetails();
        public BuyOrderDetail GetBuyOrderDetailsById(int id);
        public void CreateBuyOrderDetail(BuyOrderDetailModel buyOrderDetailModel);
        public void UpdateBuyOrderDetail(BuyOrderDetailModel buyOrderDetailModel);
        public void DeleteBuyOrderDetail(BuyOrderDetailModel buyOrderDetailModel);
    }
}
