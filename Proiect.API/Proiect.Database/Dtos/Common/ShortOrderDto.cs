﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proiect.Database.Entities;
using Proiect.Database.Enums;

namespace Proiect.Database.Dtos.Common
{
    public class ShortOrderDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatuses Status { get; set; }
        public double? Total { get; set; }

        public int? CustomerId { get; set; }
        public int? EmployeeId { get; set; }
    }
}
