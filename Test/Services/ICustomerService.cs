using Test.Entities;
using Test.Models;

namespace Test.Services
{
    public interface ICustomerService
    {
        public IEnumerable<CustomerModel> GetAllCustomers();
        public CustomerModel GetCustomerById(int id);
        public bool CreateCustomer(CustomerModel customer);
        public bool UpdateCustomer(CustomerModel customer);
        public bool DeleteCustomer(int id);
    }
}
