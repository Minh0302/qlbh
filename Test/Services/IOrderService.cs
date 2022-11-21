using Test.Entities;
using Test.Models;

namespace Test.Services
{
    public interface IOrderService
    {
        public IEnumerable<OrderModel> GetAllOrders();
        public OrderModel GetOrderById(int id);
        public bool CreateOrder(OrderModel orderModel);
        public bool UpdateOrder(OrderModel orderModel);
        public bool DeleteOrder(int id);
    }
}
