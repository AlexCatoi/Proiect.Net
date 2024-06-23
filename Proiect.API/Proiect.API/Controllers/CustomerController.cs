using Microsoft.AspNetCore.Mvc;
using Proiect.Core.Services;
using Proiect.Database.Dtos.Request;
using Proiect.Database.Entities;

namespace Proiect.API.Controllers
{
    public class CustomerController:BaseController
    {
        private CustomerService projectsService { get; set; }

        public CustomerController(CustomerService projectsService)
        {
            this.projectsService = projectsService;
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddCustomer([FromBody] AddCustomerRequest payload)
        {
            projectsService.AddCustomer(payload);

            return Ok("Customer has been successfully added");
        }
        [HttpGet]
        [Route("get-details")]
        public IActionResult GetCustomer([FromRoute] GetCustomerRequest payload)
        {
            var result = projectsService.GetCustomers(payload);

            return Ok(result);
        }

        [HttpPut]
        [Route("Update")]
        // [Authorize(Roles ="Admin")]
        public IActionResult UpdateCustomerDetails([FromBody] UpdateCustomerRequest customer)
        {
            projectsService.UpdateCustomer(customer);

            return Ok("Customer has been successfully updated");
        }

        [HttpDelete]
        [Route("Delete")]
        // [Authorize(Roles = "Admin")]
        public IActionResult DeleteCustomerDetails([FromBody] DeleteCustomerRequest customer)
        {
            projectsService.DeleteCustomer(customer);

            return Ok("Customer has been successfully deleted");
        }
    }
}
