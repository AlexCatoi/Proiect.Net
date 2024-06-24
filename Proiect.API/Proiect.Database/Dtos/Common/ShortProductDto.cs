using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.Database.Dtos.Common
{
    public class ShortProductDto
    {
        public int ProductId { get; set; }
        public string Nume { get; set; }
        public int NrBucati { get; set; }
        public double Valoare { get; set; }
        public double Greutate { get; set; }
        public double Marime { get; set; }
        public bool IsActive { get; set; }
    }
}
