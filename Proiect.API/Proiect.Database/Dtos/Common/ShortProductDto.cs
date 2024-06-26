using System;

namespace Proiect.Database.Dtos.Common
{
    public class ShortProductDto
    {
        public int? ProductId { get; set; }
        public string? Nume { get; set; }
        public int? NrBucati { get; set; }
        public double? Valoare { get; set; }
        public double? Greutate { get; set; }
        public double? Marime { get; set; }
        public bool? IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
