using MovieService.Models;

namespace MovieService.Abstractions
{
    public interface IMovieRepository
    {
        public Task<IEnumerable<Movie>> GetMoviesAsync();
        public Task<Movie> GetMovieAsync(int id);
        public Task CreateMovieAsync(Movie movie);
        public Task<bool> SaveChangesAsync(); 
    }
}
