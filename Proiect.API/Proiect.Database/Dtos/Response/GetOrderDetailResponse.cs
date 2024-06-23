using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proiect.Database.Dtos.Common;
using Proiect.Database.Enums;

namespace Proiect.Database.Dtos.Response
{
    public class GetOrderDetailResponse
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatuses Status { get; set; }

        public ShortCustomerDto Customer { get; set; }
    }
}
