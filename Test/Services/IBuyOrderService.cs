using Test.Entities;
using Test.Models;

namespace Test.Services
{
    public interface IBuyOrderService
    {
        public IEnumerable<BuyOrder> GetAllBuyOrders();
        public BuyOrder GetOrderById(int id);
        public void CreateBuyOrder(BuyOrderModel buyOrderModel);
        public void UpdateBuyOrder(BuyOrderModel buyOrderModel);
        public void DeleteBuyOrder(BuyOrderModel buyOrderModel);
    }
}
