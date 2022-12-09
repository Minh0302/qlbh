using AutoMapper;
using Test.Entities;
using Test.Helpers;
using Test.Models;
using Test.Repositories;

namespace Test.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IGenerictRepository<Customer> _generictRepository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public CustomerService(IGenerictRepository<Customer> generictRepository, IMapper mapper, ILoggerManager logger)
        {
            _generictRepository = generictRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public bool CreateCustomer(CustomerModel customer)
        {
            var newCustomer = _mapper.Map<Customer>(customer);
            try
            {
                _logger.LogInfo("CustomerService: CreateCustomer");
                _generictRepository.Create(newCustomer);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("CustomerService: CreateCustomer" + ex);
                return false;
            }
        }

        public bool DeleteCustomer(int id)
        {
            try
            {
                _logger.LogInfo("CustomerService: DeleteCustomer");
                _generictRepository.DeleteById(id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("CustomerService: DeleteCustomer" + ex);
                return false;
            }
        }

        public IEnumerable<CustomerModel> GetAllCustomers()
        {
            var customers = _generictRepository.GetAll().AsQueryable().ToList();
            return _mapper.Map<List<CustomerModel>>(customers);
        }

        public CustomerModel GetCustomerById(int id)
        {
            var customer = _generictRepository.GetById(id);
            return _mapper.Map<CustomerModel>(customer);
        }

        public bool UpdateCustomer(CustomerModel customer)
        {
            var updateCustomer = _mapper.Map<Customer>(customer);
            try
            {
                _logger.LogInfo("CustomerService: CreateCustomer");
                _generictRepository.Update(updateCustomer);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("CustomerService: DeleteCustomer" + ex);
                return false;
            }
        }
    }
}
