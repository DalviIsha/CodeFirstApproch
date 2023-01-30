using Demo_Crud_For_Customer.Entity;
using Demo_Crud_For_Customer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Crud_For_Customer.Controllers
{
    [ApiController]
    [Route("api/Customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _customer;

        public CustomerController(ICustomer customer)
        {
            _customer = customer;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(Customer customer)
        {
            return Ok(await _customer.CreateCustomer(customer));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(Customer customer)
        {
            return Ok(await _customer.UpdateCustomer(customer));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            return Ok(await _customer.DeleteCustomer(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomer(int id)
        {
            return Ok(await _customer.GetCustomerById(id));
        }
    }
}
