using AlIInOne.Models.Base;
using AlIInOne.Repositories.Base;

namespace AlIInOne.Services.Base
{
    public class BaseService<T, TRepository> : IBaseService<T>
        where T : BaseModel
        where TRepository : IBaseRepository<T>
    {
        private readonly TRepository _repository;

        public BaseService(TRepository repository)
        {
            _repository = repository;
        }

        public Task<T> Create(T t)
        {
            t.CreatedAt = DateTime.Now;
            t.UpdatedAt = DateTime.Now;
            return _repository.Create(t);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.FindAll();
        }

        public async Task<T?> GetById(Guid id)
        {
            return await _repository.Find(id);
        }

        public async Task<T> Update(T t)
        {
            return await _repository.Update(t);
        }
    }
}
