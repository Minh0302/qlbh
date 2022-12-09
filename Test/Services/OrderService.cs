using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Test.Entities;
using Test.Helpers;
using Test.Models;
using Test.Repositories;

namespace Test.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenerictRepository<Order> _generictRepository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public OrderService(IGenerictRepository<Order> generictRepository, IMapper mapper, ILoggerManager logger)
        {
            _generictRepository = generictRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public bool CreateOrder(OrderModel orderModel)
        {
            var newOrder = _mapper.Map<Order>(orderModel);
            try
            {
                _logger.LogInfo("OrderService: CreateOrder");
                _generictRepository.Create(newOrder);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("OrderService: CreateOrder" + ex);
                return false;
            }
        }

        public bool DeleteOrder(int id)
        {
            try
            {
                _logger.LogInfo("OrderService: DeleteOrder");
                _generictRepository.DeleteById(id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("OrderService: DeleteOrder" + ex);
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
                _logger.LogInfo("OrderService: UpdateOrder");
                _generictRepository.Update(updateOrder);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("OrderService: UpdateOrder" + ex);
                return false;
            }
        }
    }
}
