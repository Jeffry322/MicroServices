using AutoMapper;
using MovieService.DTOs;
using MovieService.Models;

namespace MovieService.Profiles
{
    public sealed class MoviesProfile : Profile
    {
        public MoviesProfile()
        {
            CreateMap<Movie, MovieReadDTO>();
            CreateMap<MovieWriteDTO, Movie>();
        }
    }
}
