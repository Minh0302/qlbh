using AutoMapper;
using Test.Entities;
using Test.Helpers;
using Test.Models;
using Test.Repositories;

namespace Test.Services
{
    public class BuyOrderDetailService : IBuyOrderDetailService
    {
        private readonly IGenerictRepository<BuyOrderDetail> _generictRepository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public BuyOrderDetailService(IGenerictRepository<BuyOrderDetail> generictRepository, IMapper mapper, ILoggerManager logger)
        {
            _generictRepository = generictRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public void CreateBuyOrderDetail(BuyOrderDetailModel buyOrderDetailModel)
        {
            var newBuy = _mapper.Map<BuyOrderDetail>(buyOrderDetailModel);
            _generictRepository.Create(newBuy);
        }

        public bool DeleteBuyOrderDetail(int id)
        {
            try
            {
                _logger.LogInfo("BuyOrderDetailModel: BuyOrderDetailModel");
                _generictRepository.DeleteById(id);
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError("BuyOrderDetailModel: BuyOrderDetailModel" + ex);
                return false;
            }
        }

        public IEnumerable<BuyOrderDetail> GetAllBuyOrderDetails()
        {
            var buyOrderDetails = _generictRepository.GetAll();
            return _mapper.Map<List<BuyOrderDetail>>(buyOrderDetails);
        }

        public BuyOrderDetail GetBuyOrderDetailsById(int id)
        {
            var buyOrderDetail = _generictRepository.GetById(id);
            return _mapper.Map<BuyOrderDetail>(buyOrderDetail);
        }

        public void UpdateBuyOrderDetail(BuyOrderDetailModel buyOrderDetailModel)
        {
            var updateBuyOrderDetail = _mapper.Map<BuyOrderDetail>(buyOrderDetailModel);
            _generictRepository.Update(updateBuyOrderDetail);
        }
    }
}
