using AutoMapper;
using MyFilms.Core.DTOs;
using MyFilms.Data.Entities;
using MyFilms.WebAPI.Models.Requests;

namespace MyFilms.WebAPI.Mappers
{
    public class FilmProfile : Profile
    {
        public FilmProfile()
        {
            CreateMap<FilmDto, Film>().ReverseMap();

            CreateMap<CreateOrEditRequest, FilmDto>().ReverseMap();
        }
    }
}
