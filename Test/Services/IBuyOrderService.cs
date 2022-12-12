using Test.Entities;
using Test.Models;
using Test.Paging;

namespace Test.Services
{
    public interface IBuyOrderService
    {
        public IEnumerable<BuyOrderModel> GetAllBuyOrders();
        public BuyOrderModel GetOrderById(int id);
        public bool CreateBuyOrder(BuyOrderModel buyOrderModel);
        public bool UpdateBuyOrder(BuyOrderModel buyOrderModel);
        public bool DeleteBuyOrder(int id);
        PagedList<BuyOrder> PaginateBuyOrders(PagingParameters pagingParameters);
    }
}
