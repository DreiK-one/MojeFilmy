using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyFilms.Core.DTOs;
using MyFilms.Core.Interfaces;
using MyFilms.Core.Interfaces.Data;
using MyFilms.Data.Entities;

namespace MyFilms.Domain.Services
{
    public class FilmService : IFilmService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<FilmService> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public FilmService(IMapper mapper,
            ILogger<FilmService> logger, 
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<FilmDto>> GetAllFilms()
        {
            try
            {
                return await _unitOfWork.Films.Get()
                    .OrderByDescending(f => f.CreationYear)
                    .Select(f => _mapper.Map<FilmDto>(f))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: Exception in {ex.Source}, " +
                    $"message: {ex.Message}, stacktrace: {ex.StackTrace}");
                throw;
            }
        }

        public async Task<FilmDto> GetFilmById(Guid id)
        {
            try
            {
                if (id != Guid.Empty)
                {
                    var film = await _unitOfWork.Films.GetById(id);
                    return _mapper.Map<FilmDto>(film);
                }
                else
                {
                    throw new NullReferenceException();
                } 
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: Exception in {ex.Source}, " +
                    $"message: {ex.Message}, stacktrace: {ex.StackTrace}");
                throw;
            }
        }

        public async Task<int?> AddFilm(FilmDto filmDto)
        {
            try
            {
                if (filmDto != null)
                {
                    filmDto.Id = Guid.NewGuid();
                    await _unitOfWork.Films.Add(_mapper.Map<Film>(filmDto));
                    return await _unitOfWork.Save();
                }
                else
                {
                    throw new NullReferenceException("Invalid model!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: Exception in {ex.Source}, " +
                    $"message: {ex.Message}, stacktrace: {ex.StackTrace}");
                throw;
            }
        }

        public async Task<int?> DeleteFilm(Guid id)
        {
            try
            {
                if (await _unitOfWork.Films.GetById(id) != null)
                {
                    await _unitOfWork.Films.Remove(id);
                    return await _unitOfWork.Save();
                }
                else
                {
                    throw new NullReferenceException($"Film with id {id} isn't exists in database!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: Exception in {ex.Source}, " +
                    $"message: {ex.Message}, stacktrace: {ex.StackTrace}");
                throw;
            }
        }

        public async Task<int?> EditFilm(FilmDto filmDto)
        {
            try
            {
                if (filmDto != null)
                {
                    await _unitOfWork.Films.Update(_mapper.Map<Film>(filmDto));
                    return await _unitOfWork.Save();
                }
                else
                {
                    throw new NullReferenceException("Invalid model!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: Exception in {ex.Source}, " +
                    $"message: {ex.Message}, stacktrace: {ex.StackTrace}");
                throw;
            }
        }
    }
}
