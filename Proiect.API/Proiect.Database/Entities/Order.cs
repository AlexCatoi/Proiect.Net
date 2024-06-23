using Proiect.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proiect.Database.Enums;

namespace Proiect.Database.Entities
{
    public class Order :BaseEntity

    {
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatuses Status { get; set; }

        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
    }
}
