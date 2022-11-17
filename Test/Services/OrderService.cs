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

        public void DeleteOrder(int id)
        {
            //var delOrder = _mapper.Map<Order>(orderModel);
            _generictRepository.DeleteById(id);
        }

        public IEnumerable<OrderModel> GetAllOrders()
        {
            var orders = _generictRepository.GetAll().AsQueryable().AsNoTracking().Include(obj => obj.OrderDetails);
            return _mapper.Map<List<OrderModel>>(orders);
        }

        public OrderModel GetOrderById(int id)
        {
            var order = _generictRepository.GetAll().AsQueryable().AsNoTracking().Include(obj => obj.OrderDetails).FirstOrDefault(x => x.Id == id);
            return _mapper.Map<OrderModel>(order);
        }

        public void UpdateOrder(OrderModel orderModel)
        {
            var updateOrder = _mapper.Map<Order>(orderModel);
            _generictRepository.Update(updateOrder);
        }
    }
}
