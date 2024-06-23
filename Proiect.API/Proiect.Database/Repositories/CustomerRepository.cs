using Microsoft.EntityFrameworkCore;
using Proiect.Database.Context;
using Proiect.Database.Dtos.Request;
using Proiect.Database.Entities;
using Proiect.Database.QueryExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.Database.Repositories
{
    public class CustomerRepository:BaseRepository
    {
        public CustomerRepository(ProiectDBContext temaDbContext) : base(temaDbContext)
        {
        }

        public void Add(Customer customer)
        {
            labProjectDbContext.Customers.Add(customer);
            labProjectDbContext.SaveChanges();
        }


        private IQueryable<Customer> GetCustomersQuery(GetCustomerRequest payload)
        {
            var query = labProjectDbContext.Customers

                .Where(e => e.DateDeleted == null);

            return query;

        }
        public List<Customer> GetCustomers(GetCustomerRequest payload)
        {
            var results = GetCustomersQuery(payload)
                .AsNoTracking()
                .ToList();

            return results;
        }
        public int CountCustomers(GetCustomerRequest payload)
        {
            var count = GetCustomersQuery(payload)
                .Count();

            return count;
        }

        public void Update(Customer customer)
        {
            labProjectDbContext.Customers.Update(customer);
            labProjectDbContext.SaveChanges();
        }
        public void Delete(Customer customer)
        {
            labProjectDbContext.Customers.Remove(customer);
            labProjectDbContext.SaveChanges();
        }
    }
}
