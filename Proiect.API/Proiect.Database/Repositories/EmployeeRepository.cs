using Microsoft.EntityFrameworkCore;
using Proiect.Database.Context;
using Proiect.Database.Dtos.Request;
using Proiect.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.Database.Repositories
{
    public class EmployeeRepository:BaseRepository
    {
        public EmployeeRepository(ProiectDBContext temaDbContext) : base(temaDbContext)
        {
        }

        public void Add(Employee employee)
        {
            labProjectDbContext.Employees.Add(employee);
            labProjectDbContext.SaveChanges();
        }


        private IQueryable<Employee> GetEmployeesQuery(GetEmployeeRequest payload)
        {
            var query = labProjectDbContext.Employees;

            return query;

        }
        public List<Employee> GetEmployees(GetEmployeeRequest payload)
        {
            var results = GetEmployeesQuery(payload)
                .AsNoTracking()
                .ToList();

            return results;
        }
        public int CountEmployees(GetEmployeeRequest payload)
        {
            var count = GetEmployeesQuery(payload)
                .Count();

            return count;
        }

        public void Update(Employee employee)
        {
            labProjectDbContext.Employees.Update(employee);
            labProjectDbContext.SaveChanges();
        }
        public void Delete(Employee employee)
        {
            labProjectDbContext.Employees.Remove(employee);
            labProjectDbContext.SaveChanges();
        }
    }
}
