using Proiect.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proiect.Database.Dtos.Common;

namespace Proiect.Database.Dtos.Response
{
    public class GetEmployeesResponse
    {
        public List<ShortEmployeeDto> Employees { get; set; }
        public int Count { get; set; }
    }
}
