using Proiect.Database.Context;

namespace Proiect.Database.Repositories
{
    public class BaseRepository
    {
        protected ProiectDBContext labProjectDbContext { get; set; }

        public BaseRepository(ProiectDBContext labProjectDbContext)
        {
            this.labProjectDbContext = labProjectDbContext;
        }

        public void SaveChanges()
        {
            labProjectDbContext.SaveChanges();
        }
    }
}
