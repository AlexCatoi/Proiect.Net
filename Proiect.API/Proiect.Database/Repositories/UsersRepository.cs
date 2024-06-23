
using Proiect.Database.Entities;
using Proiect.Database.Context;

namespace Proiect.Database.Repositories
{
    public class UsersRepository:BaseRepository
    {
        public UsersRepository(ProiectDBContext labProjectDbContext) : base(labProjectDbContext) {}

        public void Add(User user)
        {
            labProjectDbContext.Users.Add(user);
            labProjectDbContext.SaveChanges();
        }

        public User GetByEmail(string email)
        {
            var result = labProjectDbContext.Users

                .Where(e => e.Email == email)
                .Where(e => e.DateDeleted == null)

                .FirstOrDefault();

            return result;
        }
    }
}
