using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Test.Entities;
using Test.Helpers;
using Test.Models;
using Test.Repositories;

namespace Test.Services
{
    public class BuyOrderService : IBuyOrderService
    {
        private readonly IGenerictRepository<BuyOrder> _generictRepository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public BuyOrderService(IGenerictRepository<BuyOrder> generictRepository, IMapper mapper, ILoggerManager logger)
        {
            _generictRepository = generictRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public bool CreateBuyOrder(BuyOrderModel buyOrderModel)
        {
            var newBuy = _mapper.Map<BuyOrder>(buyOrderModel);
            try
            {
                _logger.LogInfo("BuyOrderService: CreateBuyOrder");
                _generictRepository.Create(newBuy);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("BuyOrderService: CreateBuyOrder" + ex);
                return false;
            }
        }

        public bool DeleteBuyOrder(int id)
        {
            try
            {
                _logger.LogInfo("BuyOrderService: DeleteBuyOrder");
                _generictRepository.DeleteById(id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("BuyOrderService: DeleteBuyOrder" + ex);
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
                _logger.LogInfo("BuyOrderService: UpdateBuyOrder");
                _generictRepository.Update(updateBuy);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("BuyOrderService: UpdateBuyOrder" + ex);
                return false;
            }
        }
    }
}
