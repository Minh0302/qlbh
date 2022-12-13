using Test.Entities;
using Test.Models;

namespace Test.Services
{
    public interface IOrderDetailService
    {
        public IEnumerable<OrderDetail> GetAllOrderDetails();
        public OrderDetail GetOrderDetailById(int id);
        public void CreateOrderDetail(OrderDetailModel orderDetailModel);
        public void UpdateOrderDetail(OrderDetailModel orderDetailModel);
        public bool DeleteOrderDetail(int id);
    }
}
