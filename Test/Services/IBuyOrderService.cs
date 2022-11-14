using Test.Entities;
using Test.Models;

namespace Test.Services
{
    public interface IBuyOrderService
    {
        public IEnumerable<BuyOrder> GetAllBuyOrders();
        public BuyOrder GetOrderById(int id);
        public void CreateBuyOrder(BuyOrderModel buyOrderDetailModel);
        public void UpdateBuyOrder(BuyOrderModel buyOrderDetailModel);
        public void DeleteBuyOrder(BuyOrderModel buyOrderDetailModel);
    }
}
