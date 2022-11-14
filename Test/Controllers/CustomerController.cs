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
        public ActionResult Post(CustomerModel customer)
        {
            _customerService.CreateCustomer(customer);
            return Ok("Thêm thành công!");
        }
        [HttpPut]
        public ActionResult Put(CustomerModel customer)
        {
            _customerService.UpdateCustomer(customer);
            return Ok("Update thành công!");
        }
        [HttpDelete]
        public ActionResult Delete(CustomerModel customer)
        {
            _customerService.DeleteCustomer(customer);
            return Ok("Delete thành công!");
        }
    }
}
