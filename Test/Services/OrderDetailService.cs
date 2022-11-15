using AutoMapper;
using Test.Entities;
using Test.Models;
using Test.Repositories;

namespace Test.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IGenerictRepository<OrderDetail> _generictRepository;
        private readonly IMapper _mapper;

        public OrderDetailService(IGenerictRepository<OrderDetail> generictRepository, IMapper mapper)
        {
            _generictRepository = generictRepository;
            _mapper = mapper;
        }
        public void CreateOrderDetail(OrderDetailModel orderDetailModel)
        {
            var newOrder = _mapper.Map<OrderDetail>(orderDetailModel);
            _generictRepository.Create(newOrder);
        }

        public void DeleteOrderDetail(OrderDetailModel orderDetailModel)
        {
            var delOrder = _mapper.Map<OrderDetail>(orderDetailModel);
            _generictRepository.Delete(delOrder);
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
