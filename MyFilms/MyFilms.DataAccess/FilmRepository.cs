using MyFilms.Data;
using MyFilms.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFilms.DataAccess
{
    public class FilmRepository : BaseRepository<Film>
    {
        public FilmRepository(MyFilmsContext context) : base(context)
        {
        }
    }
}
