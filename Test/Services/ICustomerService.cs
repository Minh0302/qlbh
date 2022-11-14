using Test.Entities;
using Test.Models;

namespace Test.Services
{
    public interface ICustomerService
    {
        public IEnumerable<Customer> GetAllCustomers();
        public Customer GetCustomerById(int id);
        public void CreateCustomer(CustomerModel customer);
        public void UpdateCustomer(CustomerModel customer);
        public void DeleteCustomer(CustomerModel customer);
    }
}
