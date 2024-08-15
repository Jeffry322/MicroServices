using MovieService.DTOs;

namespace MovieService.Abstractions
{
    public interface IActorsDataClient
    {
        public Task SendMovieToActor(MovieReadDTO movieReadDTO);
    }
}
