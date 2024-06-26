using Proiect.Database.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.Database.Dtos.Request
{
    public class UpdateOrderRequest
    {
        public int? OrderId { get; set; } 
        public int? AssignedCustomerIds { get; set; }
        public int? AssignedEmployeeIds { get; set; }
        public double? Total { get; set; }
        public OrderStatuses? Status { get; set; }
    }
}
