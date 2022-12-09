using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Helpers;
using Test.Models;
using Test.Services;

namespace Test.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ILoggerManager _logger;

        public CustomerController(ICustomerService customerService, ILoggerManager logger)
        {
            _customerService = customerService;
            _logger = logger;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            _logger.LogInfo("CustomerController : GetAll");
            return Ok(_customerService.GetAllCustomers());
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            _logger.LogInfo("CustomerController : GetById");
            return Ok(_customerService.GetCustomerById(id));
        }
        [HttpPost]
        public bool Post(CustomerModel customer)
        {
            _logger.LogInfo("CustomerController : Post");
            return _customerService.CreateCustomer(customer);
        }
        [HttpPut]
        public bool Put(CustomerModel customer)
        {
            _logger.LogInfo("CustomerController : Put");
            return _customerService.UpdateCustomer(customer);
        }
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            _logger.LogInfo("CustomerController : Delete");
            return _customerService.DeleteCustomer(id);
        }
    }
}
