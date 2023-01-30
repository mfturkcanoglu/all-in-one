using AlIInOne.Models;
using AlIInOne.Repositories;
using AlIInOne.Services.Base;

namespace AlIInOne.Services
{
    public class LecturerService : BaseService<Lecturer, ILecturerRepository>, ILecturerService
    {
        public LecturerService(ILecturerRepository repository) : base(repository)
        {
        }
    }
}
