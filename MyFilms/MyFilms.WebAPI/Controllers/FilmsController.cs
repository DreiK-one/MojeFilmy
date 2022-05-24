using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFilms.Core.DTOs;
using MyFilms.Core.Interfaces;
using MyFilms.WebAPI.Models.Requests;
using MyFilms.WebAPI.Models.Responses;
using System.Net;

namespace MyFilms.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<FilmsController> _logger;
        private readonly IFilmService _filmService;

        public FilmsController(IMapper mapper, 
            ILogger<FilmsController> logger, 
            IFilmService filmService)
        {
            _mapper = mapper;
            _logger = logger;
            _filmService = filmService;
        }

        [HttpGet("{id}"), AllowAnonymous]
        [ProducesResponseType(typeof(FilmDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseMessage), 500)]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("Identificator is null");
                }

                var film = await _filmService.GetFilmById(id);

                if (film != null)
                {
                    return Ok(film);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: Exception in {ex.Source}, " +
                    $"message: {ex.Message}, stacktrace: {ex.StackTrace}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet, AllowAnonymous]
        [ProducesResponseType(typeof(FilmDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseMessage), 500)]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var films = await _filmService.GetAllFilms();

                if (films != null)
                {
                    return Ok(films);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: Exception in {ex.Source}, " +
                    $"message: {ex.Message}, stacktrace: {ex.StackTrace}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost, AllowAnonymous]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Create(CreateOrEditRequest request)
        {
            try
            {
                if (!ModelState.IsValid || request == null)
                {
                    return BadRequest("Request is null or invalid");
                }

                await _filmService.AddFilm(_mapper.Map<FilmDto>(request));
                return Ok("Film added!");
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: Exception in {ex.Source}, " +
                    $"message: {ex.Message}, stacktrace: {ex.StackTrace}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}"), AllowAnonymous]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Edit(Guid id, [FromBody] CreateOrEditRequest request)
        {
            try
            {
                if (!ModelState.IsValid || request == null)
                {
                    return BadRequest("Request is null or invalid");
                }
                var film = await _filmService.GetFilmById(id);
                if (film == null)
                {
                    return BadRequest($"Film with id {id} not found");
                }

                film.Title = request.Title;
                film.Description = request.Description;
                film.CreationYear = request.CreationYear;

                await _filmService.EditFilm(film);
                return Ok("Changes applied!");
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: Exception in {ex.Source}, " +
                    $"message: {ex.Message}, stacktrace: {ex.StackTrace}");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}"), AllowAnonymous]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("Identificator is null" );
                }

                await _filmService.DeleteFilm(id);
                return Ok("Film deleted!");
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: Exception in {ex.Source}, " +
                    $"message: {ex.Message}, stacktrace: {ex.StackTrace}");
                return StatusCode(500, ex.Message);
            }
        }
    }
}
