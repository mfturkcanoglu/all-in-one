using AlIInOne.Context;
using AlIInOne.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace AlIInOne.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        private readonly AllInOneDbContext _db;
        private DbSet<T> _dbSet;

        public BaseRepository(AllInOneDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await Find(id);
            if (entity is null)
            {
                return false;
            }
            _dbSet.Remove(entity);
            return true;
        }

        public async Task<T?> Find(Guid id)
        {
            return await _dbSet.FirstOrDefaultAsync(t => t.Id == id);
        }

        public IEnumerable<T> FindAll()
        {
            return _dbSet.OrderByDescending(t => t.CreatedAt).AsEnumerable<T>();
        }

        public async Task<T> Create(T t)
        {
            var entity = await _dbSet.AddAsync(t);
            await SaveChangesAsync();
            return entity.Entity;
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<T> Update(T t)
        {
            _dbSet.Attach(t);
            var entry = _dbSet.Entry(t);
            entry.State = EntityState.Modified;

            // Specify the properties will not be modified
            entry.Property(e => e.CreatedAt).IsModified = false;
            entry.Property(e => e.DeletedAt).IsModified = false;
            entry.Property(e => e.Deleted).IsModified = false;
            entry.Property(e => e.Id).IsModified = false;

            await SaveChangesAsync();
            return t;
        }
    }
}
