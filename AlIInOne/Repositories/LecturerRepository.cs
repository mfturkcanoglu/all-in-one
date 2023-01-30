using AlIInOne.Context;
using AlIInOne.Models;
using AlIInOne.Repositories.Base;

namespace AlIInOne.Repositories
{
    public class LecturerRepository : BaseRepository<Lecturer>, ILecturerRepository
    {
        public LecturerRepository(AllInOneDbContext db) : base(db)
        {
        }
    }
}
