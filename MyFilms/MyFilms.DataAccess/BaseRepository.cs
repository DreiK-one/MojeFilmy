using Microsoft.EntityFrameworkCore;
using MyFilms.Core.Interfaces.Data;
using MyFilms.Data;
using MyFilms.Data.Entities;
using System.Linq.Expressions;


namespace MyFilms.DataAccess
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly MyFilmsContext Db;
        protected readonly DbSet<T> DbSet;

        public BaseRepository(MyFilmsContext db)
        {
            Db = db;
            DbSet = Db.Set<T>();
        }

        public async Task Add(T entity)
        {
            await DbSet.AddAsync(entity);
        }

        public IQueryable<T> Get()
        {
            return DbSet.AsNoTracking();
        }

        public async Task<T> GetById(Guid id)
        {
            return await DbSet.AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id.Equals(id));
        }

        public async Task<IQueryable<T>> FindBy(Expression<Func<T, bool>> predicate, 
            params Expression<Func<T, object>>[] includes)
        {
            var result = DbSet.AsNoTracking().Where(predicate);
            if (includes.Any())
            {
                result = includes.Aggregate(result, 
                    (current, include) => current.Include(include));
            }
            return result;
        }

        public async Task Update(T entity)
        {
            DbSet.Update(entity);
        }

        public async Task Patch(Guid id, List<PatchModel> patchDtos)
        {
            var model = await DbSet
                .FirstOrDefaultAsync(e => e.Id.Equals(id));
            var nameValuePair = patchDtos
                .ToDictionary(a => a.PropertyName, a => a.PropertyValue);
            var entryEntity = Db.Entry(model);
            
            entryEntity.CurrentValues.SetValues(nameValuePair);
            entryEntity.State = EntityState.Modified;

        }

        public async Task Remove(Guid id)
        {
            DbSet.Remove(await DbSet.FindAsync(id));
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
