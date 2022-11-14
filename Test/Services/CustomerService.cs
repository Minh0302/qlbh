using AutoMapper;
using Test.Entities;
using Test.Models;
using Test.Repositories;

namespace Test.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IGenerictRepository<Customer> _generictRepository;
        private readonly IMapper _mapper;

        public CustomerService(IGenerictRepository<Customer> generictRepository, IMapper mapper)
        {
            _generictRepository = generictRepository;
            _mapper = mapper;
        }
        public void CreateCustomer(CustomerModel customer)
        {
            var newCustomer = _mapper.Map<Customer>(customer);
            _generictRepository.Create(newCustomer);
        }

        public void DeleteCustomer(CustomerModel customer)
        {
            var deCustomer= _mapper.Map<Customer>(customer);
            _generictRepository.Delete(deCustomer);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var customers = _generictRepository.GetAll();
            return _mapper.Map<List<Customer>>(customers);
        }

        public Customer GetCustomerById(int id)
        {
            var customer = _generictRepository.GetById(id);
            return _mapper.Map<Customer>(customer);
        }

        public void UpdateCustomer(CustomerModel customer)
        {
            var updateCustomer = _mapper.Map<Customer>(customer);
            _generictRepository.Update(updateCustomer);
        }
    }
}
