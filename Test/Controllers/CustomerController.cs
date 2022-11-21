using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Test.Services;

namespace Test.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_customerService.GetAllCustomers());
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(_customerService.GetCustomerById(id));
        }
        [HttpPost]
        public bool Post(CustomerModel customer)
        {
            return _customerService.CreateCustomer(customer);
        }
        [HttpPut]
        public bool Put(CustomerModel customer)
        {
            return _customerService.UpdateCustomer(customer);
        }
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _customerService.DeleteCustomer(id);
        }
    }
}
