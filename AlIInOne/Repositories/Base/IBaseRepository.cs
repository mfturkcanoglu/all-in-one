using AlIInOne.Models.Base;

namespace AlIInOne.Repositories.Base
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        public IEnumerable<T> FindAll();
        public Task<T?> Find(Guid id);
        public Task<T> Create(T t);
        public Task<T> Update(T t);
        public Task<bool> Delete(Guid id);
        public Task SaveChangesAsync();
    }
}
