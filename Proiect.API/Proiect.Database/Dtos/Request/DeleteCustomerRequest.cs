using Proiect.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.Database.Dtos.Request
{
    public class DeleteCustomerRequest
    {
        public int? CustomerId { get; set; }
    }
}
