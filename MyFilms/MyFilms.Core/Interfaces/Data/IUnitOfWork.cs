using MyFilms.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFilms.Core.Interfaces.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Film> Films { get; }
        Task<int> Save();
    }
}
