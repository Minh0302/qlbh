using Test.Entities;
using Test.Models;

namespace Test.Services
{
    public interface ICustomerService
    {
        public IEnumerable<CustomerModel> GetAllCustomers();
        public CustomerModel GetCustomerById(int id);
        public void CreateCustomer(CustomerModel customer);
        public void UpdateCustomer(CustomerModel customer);
        public void DeleteCustomer(int id);
    }
}
