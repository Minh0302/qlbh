using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Test.Entities;
using Test.Models;
using Test.Repositories;

namespace Test.Services
{
    public class BuyOrderService : IBuyOrderService
    {
        private readonly IGenerictRepository<BuyOrder> _generictRepository;
        private readonly IMapper _mapper;

        public BuyOrderService(IGenerictRepository<BuyOrder> generictRepository, IMapper mapper)
        {
            _generictRepository = generictRepository;
            _mapper = mapper;
        }
        public void CreateBuyOrder(BuyOrderModel buyOrderModel)
        {
            var newBuy = _mapper.Map<BuyOrder>(buyOrderModel);
            _generictRepository.Create(newBuy);
        }

        public void DeleteBuyOrder(BuyOrderModel buyOrderModel)
        {
            var delBuy = _mapper.Map<BuyOrder>(buyOrderModel);
            _generictRepository.Delete(delBuy);
        }

        public IEnumerable<BuyOrderModel> GetAllBuyOrders()
        {
            var buyorders = _generictRepository.GetAll().AsQueryable().AsNoTracking().Include(odb=>odb.BuyOrderDetails);
            return _mapper.Map<List<BuyOrderModel>>(buyorders);
        }

        public BuyOrder GetOrderById(int id)
        {
            var buyorder = _generictRepository.GetById(id);
            return _mapper.Map<BuyOrder>(buyorder);
        }

        public void UpdateBuyOrder(BuyOrderModel buyOrderModel)
        {
            var updateBuy = _mapper.Map<BuyOrder>(buyOrderModel);
            _generictRepository.Update(updateBuy);
        }
    }
}
