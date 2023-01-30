using AlIInOne.Context;
using AlIInOne.Models;
using AlIInOne.Repositories.Base;

namespace AlIInOne.Repositories
{
    public class LessonRepository : BaseRepository<Lesson>, ILessonRepository
    {
        public LessonRepository(AllInOneDbContext db) : base(db)
        {
        }
    }
}
