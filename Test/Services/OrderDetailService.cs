using AutoMapper;
using Test.Entities;
using Test.Helpers;
using Test.Models;
using Test.Repositories;

namespace Test.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IGenerictRepository<OrderDetail> _generictRepository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public OrderDetailService(IGenerictRepository<OrderDetail> generictRepository, IMapper mapper, ILoggerManager logger)
        {
            _generictRepository = generictRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public void CreateOrderDetail(OrderDetailModel orderDetailModel)
        {
            var newOrder = _mapper.Map<OrderDetail>(orderDetailModel);
            _generictRepository.Create(newOrder);
        }

        public bool DeleteOrderDetail(int id)
        {
            try
            {
                _logger.LogInfo("OrderDetailModel: DeleteOrderDetail");
                _generictRepository.DeleteById(id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("OrderDetailModel: DeleteOrderDetail" + ex);
                return false;
            }
        }

        public IEnumerable<OrderDetail> GetAllOrderDetails()
        {
            var orderDetails  =  _generictRepository.GetAll();
            return _mapper.Map<List<OrderDetail>>(orderDetails);
        }

        public OrderDetail GetOrderDetailById(int id)
        {
            var orderDetail = _generictRepository.GetById(id);
            return _mapper.Map<OrderDetail>(orderDetail);
        }

        public void UpdateOrderDetail(OrderDetailModel orderDetailModel)
        {
            var updateOrder = _mapper.Map<OrderDetail>(orderDetailModel);
            _generictRepository.Update(updateOrder);
        }
    }
}
