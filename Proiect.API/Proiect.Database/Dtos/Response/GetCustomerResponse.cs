using Proiect.Database.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.Database.Dtos.Response
{
    public class GetCustomerResponse
    {
        public List<ShortCustomerDto> Customers { get; set; }
        public int Count { get; set; }
    }
}
