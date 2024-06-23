using Proiect.Database.Context;
using Proiect.Database.Dtos.Request;
using Proiect.Database.Dtos.Response;
using Proiect.Core.Mapping;
using Proiect.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.Core.Services
{
    public class EmployeeService
    {
        private EmployeeRepository employeeRepository { get; set; }

        public EmployeeService(EmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public void AddEmployee(AddEmployeeRequest payload)
        {
            var project = payload.ToEntity();

            employeeRepository.Add(project);
        }

        public GetEmployeesResponse GetEmployees(GetEmployeeRequest payload)
        {
            var employees = employeeRepository.GetEmployees(payload);

            var result = new GetEmployeesResponse();
            result.Employees = employees.ToEmployeesDtos();
            result.Count = employeeRepository.CountEmployees(payload);

            return result;
        }

        public void UpdateEmployee(UpdateEmployeeRequest payload)
        {
            var dbContext = new ProiectDBContext();

            var existingCustomer = dbContext.Employees.FirstOrDefault(o => o.EmployeeId == payload.EmployeeId);

            if (existingCustomer == null)
            {

                return;
            }

            existingCustomer.FirstName = payload.FirstName;
            existingCustomer.LastName = payload.LastName;
            existingCustomer.Email = payload.Email;
            existingCustomer.Phone = payload.Phone;

            employeeRepository.Update(existingCustomer);
        }


        public void DeleteEmployee(DeleteEmployeeRequest payload)
        {
            var dbContext = new ProiectDBContext();

            var existingOrder = dbContext.Employees.FirstOrDefault(o => o.EmployeeId == payload.EmployeeId);

            if (existingOrder == null)
            {
                //throw exception
                return;
            }
            
            employeeRepository.Delete(existingOrder);
        }
    }
}
