using AlIInOne.Models.Base;

namespace AlIInOne.Services.Base
{
    public interface IBaseService<T>
        where T : BaseModel
    {
        public IEnumerable<T> GetAll();
        public Task<T?> GetById(Guid id);
        public Task<T> Create(T t);
        public Task<T> Update(T t);
        public Task<bool> Delete(Guid id);
    }
}
