using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Test.Entities;
using Test.Models;
using Test.Repositories;

namespace Test.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenerictRepository<Order> _generictRepository;
        private readonly IMapper _mapper;

        public OrderService(IGenerictRepository<Order> generictRepository, IMapper mapper)
        {
            _generictRepository = generictRepository;
            _mapper = mapper;
        }
        public void CreateOrder(OrderModel orderModel)
        {
            var newOrder = _mapper.Map<Order>(orderModel);
            _generictRepository.Create(newOrder);
        }

        public void DeleteOrder(OrderModel orderModel)
        {
            var delOrder = _mapper.Map<Order>(orderModel);
            _generictRepository.Delete(delOrder);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            var orders = _generictRepository.GetAll().AsQueryable().AsNoTracking().Include(obj => obj.OrderDetails);
            return _mapper.Map<List<Order>>(orders);
        }

        public Order GetOrderById(int id)
        {
            var order = _generictRepository.GetById(id);
            return _mapper.Map<Order>(order);
        }

        public void UpdateOrder(OrderModel orderModel)
        {
            var updateOrder = _mapper.Map<Order>(orderModel);
            _generictRepository.Update(updateOrder);
        }
    }
}
