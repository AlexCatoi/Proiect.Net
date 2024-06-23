using Microsoft.AspNetCore.Mvc;
using Proiect.Core.Services;
using Proiect.Database.Dtos.Request;
using Proiect.Database.Entities;

namespace Proiect.API.Controllers
{
    public class EmployeeController:BaseController
    {
        private EmployeeService projectsService { get; set; }

        public EmployeeController(EmployeeService projectsService)
        {
            this.projectsService = projectsService;
        }

        [HttpPost]
        [Route("add-Employee")]
        public IActionResult AddEmployee([FromBody] AddEmployeeRequest payload)
        {
            projectsService.AddEmployee(payload);

            return Ok("Employee has been successfully added");
        }

        [HttpGet]
        [Route("get-Employee-Details")]
        public IActionResult GetEmployee([FromRoute] GetEmployeeRequest payload)
        {
            var result = projectsService.GetEmployees(payload);

            return Ok(result);
        }

        [HttpPut]
        [Route("Update-Employee")]
        // [Authorize(Roles ="Admin")]
        public IActionResult UpdateEmployeeDetails([FromBody] UpdateEmployeeRequest employee)
        {
            projectsService.UpdateEmployee(employee);

            return Ok("Customer has been successfully updated");
        }

        [HttpDelete]
        [Route("Delete-Employee")]
        // [Authorize(Roles = "Admin")]
        public IActionResult DeleteCustomerDetails([FromBody] DeleteEmployeeRequest employee)
        {
            projectsService.DeleteEmployee(employee);

            return Ok("Customer has been successfully deleted");
        }
    }
}
