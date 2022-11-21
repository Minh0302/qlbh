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
        public bool CreateOrder(OrderModel orderModel)
        {
            var newOrder = _mapper.Map<Order>(orderModel);
            try
            {
                _generictRepository.Create(newOrder);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteOrder(int id)
        {
            //var delOrder = _mapper.Map<Order>(orderModel);
            try
            {
                _generictRepository.DeleteById(id);
                return true;
            }
            catch
            {
                return false;
            }
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

        public bool UpdateOrder(OrderModel orderModel)
        {
            var updateOrder = _mapper.Map<Order>(orderModel);
            try
            {
                _generictRepository.Update(updateOrder);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
