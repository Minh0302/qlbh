using Test.Entities;
using Test.Models;

namespace Test.Services
{
    public interface IOrderService
    {
        public IEnumerable<OrderModel> GetAllOrders();
        public Order GetOrderById(int id);
        public void CreateOrder(OrderModel orderModel);
        public void UpdateOrder(OrderModel orderModel);
        public void DeleteOrder(OrderModel orderModel);
    }
}
