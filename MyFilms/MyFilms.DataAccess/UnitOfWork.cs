using MyFilms.Core.Interfaces.Data;
using MyFilms.Data;
using MyFilms.Data.Entities;


namespace MyFilms.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyFilmsContext _db;
        private readonly IBaseRepository<Film> _filmsRepository;

        public UnitOfWork(MyFilmsContext db, 
            IBaseRepository<Film> filmsRepository)
        {
            _db = db;
            _filmsRepository = filmsRepository;
        }

        public IBaseRepository<Film> Films  => _filmsRepository;
        
        public async Task<int> Save()
        {
            return await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
