using MyFilms.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFilms.Core.Interfaces
{
    public interface IFilmService
    {
        Task<FilmDto> AddFilm(FilmDto film);
        Task<FilmDto> GetFilmById(Guid id);
        Task<IEnumerable<FilmDto>> GetAllFilms();
        Task<FilmDto> EditFilm(FilmDto film);
        Task<int> DeleteFilm(Guid id);  
    }
}
