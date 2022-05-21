using MyFilms.Core.DTOs;


namespace MyFilms.Core.Interfaces
{
    public interface IFilmService
    {
        Task<int?> AddFilm(FilmDto filmDto);
        Task<FilmDto> GetFilmById(Guid id);
        Task<IEnumerable<FilmDto>> GetAllFilms();
        Task<int?> EditFilm(FilmDto filmDto);
        Task<int?> DeleteFilm(Guid id);  
    }
}
