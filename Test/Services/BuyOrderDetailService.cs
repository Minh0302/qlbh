using AutoMapper;
using Test.Entities;
using Test.Models;
using Test.Repositories;

namespace Test.Services
{
    public class BuyOrderDetailService : IBuyOrderDetailService
    {
        private readonly IGenerictRepository<BuyOrderDetail> _generictRepository;
        private readonly IMapper _mapper;

        public BuyOrderDetailService(IGenerictRepository<BuyOrderDetail> generictRepository, IMapper mapper)
        {
            _generictRepository = generictRepository;
            _mapper = mapper;
        }
        public void CreateBuyOrderDetail(BuyOrderDetailModel buyOrderDetailModel)
        {
            var newBuy = _mapper.Map<BuyOrderDetail>(buyOrderDetailModel);
            _generictRepository.Create(newBuy);
        }

        public void DeleteBuyOrderDetail(BuyOrderDetailModel buyOrderDetailModel)
        {
            var delBuy = _mapper.Map<BuyOrderDetail>(buyOrderDetailModel);
            _generictRepository.Delete(delBuy);
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
