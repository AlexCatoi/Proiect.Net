using Proiect.Database.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.Database.Dtos.Response
{
    public class GetProductResponse
    {
        public List<ShortProductDto> Products { get; set; }
        public int Count { get; set; }
    }
}
