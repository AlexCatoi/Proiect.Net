namespace Proiect.Database.Dtos.Request
{
    public class GetProductRequest
    {
        public string? Nume { get; set; }
        //public int? NrBucati { get; set; }
        public double? Valoare { get; set; }
        //public double? Greutate { get; set; }
        //public double? Marime { get; set; }
        public bool? IsActive { get; set; }
    }
}
