using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proiect.Database.Dtos.Common;
using Proiect.Database.Entities;
using Proiect.Database.Enums;

namespace Proiect.Database.Dtos.Request
{
    public class AddOrderRequest
    {
        public int? CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public double? Total { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatuses Status { get; set; }

        public List<ShortOrderProductDto> OrderProducts { get; set; }
    }

}
