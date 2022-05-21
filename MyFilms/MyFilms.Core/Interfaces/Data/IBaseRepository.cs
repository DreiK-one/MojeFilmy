using MyFilms.Data;
using MyFilms.Data.Entities;
using System.Linq.Expressions;


namespace MyFilms.Core.Interfaces.Data
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task Add(T entity);
        Task<T> GetById(Guid id);
        IQueryable<T> Get();
        Task Update(T entity);
        Task Patch(Guid id, List<PatchModel> patchDtos);
        Task Remove(Guid id);
        Task <IQueryable<T>> FindBy(Expression<Func<T, bool>> predicate, 
            params Expression<Func<T, object>>[] includes);
        void Dispose();
    }
}
