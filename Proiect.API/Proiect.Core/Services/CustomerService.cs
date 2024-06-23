using Proiect.Core.Mapping;
using Proiect.Database.Dtos.Request;
using Proiect.Database.Dtos.Response;
using Proiect.Database.Repositories;
using Proiect.Database.Entities;
using Proiect.Database.Context;

namespace Proiect.Core.Services
{
    public class CustomerService
    {
        private CustomerRepository customerRepository { get; set; }

        public CustomerService(CustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public void AddCustomer(AddCustomerRequest payload)
        {
            var project = payload.ToEntity();

            customerRepository.Add(project);
        }

        public GetCustomerResponse GetCustomers(GetCustomerRequest payload)
        {
            var customers = customerRepository.GetCustomers(payload);

            var result = new GetCustomerResponse();
            result.Customers = customers.ToCustomerDtos();
            result.Count = customerRepository.CountCustomers(payload);

            return result;
        }

        public void UpdateCustomer(UpdateCustomerRequest payload)
        {
            var dbContext = new ProiectDBContext();

            var existingCustomer = dbContext.Customers.FirstOrDefault(o => o.CustomerId == payload.CustomerId);

            if (existingCustomer == null)
            {

                return;
            }
            existingCustomer.DateUpdated = DateTime.UtcNow;
            existingCustomer.FirstName= payload.FirstName;
            existingCustomer.LastName= payload.LastName;
            existingCustomer.Email= payload.Email;
            existingCustomer.Phone= payload.Phone;

            customerRepository.Update(existingCustomer);
        }


        public void DeleteCustomer(DeleteCustomerRequest payload)
        {
            var dbContext = new ProiectDBContext();

            var existingOrder = dbContext.Customers.FirstOrDefault(o => o.CustomerId == payload.CustomerId);

            if (existingOrder == null)
            {
                //throw exception
                return;
            }
            customerRepository.Delete(existingOrder);
        }
    }
}
