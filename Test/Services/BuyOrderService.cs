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
        public bool CreateBuyOrder(BuyOrderModel buyOrderModel)
        {
            var newBuy = _mapper.Map<BuyOrder>(buyOrderModel);
            try
            {
                _generictRepository.Create(newBuy);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteBuyOrder(int id)
        {
            //var delBuy = _mapper.Map<BuyOrder>(buyOrderModel);
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

        public IEnumerable<BuyOrderModel> GetAllBuyOrders()
        {
            var buyorders = _generictRepository.GetAll().AsQueryable().AsNoTracking().Include(odb=>odb.BuyOrderDetails);
            return _mapper.Map<List<BuyOrderModel>>(buyorders);
        }

        public BuyOrderModel GetOrderById(int id)
        {
            var buyorder = _generictRepository.GetAll().AsQueryable().AsNoTracking().Include(odb => odb.BuyOrderDetails).FirstOrDefault(x => x.Id ==id);
            return _mapper.Map<BuyOrderModel>(buyorder);
        }

        public bool UpdateBuyOrder(BuyOrderModel buyOrderModel)
        {
            var updateBuy = _mapper.Map<BuyOrder>(buyOrderModel);
            try
            {
                _generictRepository.Update(updateBuy);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
