using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proiect.Database.Enums;

namespace Proiect.Database.Dtos.Request
{
    public class GetOrderRequest
    {
        public int? AssignedCustomerIds { get; set; }
        public OrderStatuses? Status { get; set; }
    }
}
