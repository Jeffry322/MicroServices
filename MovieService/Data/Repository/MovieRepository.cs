using Microsoft.EntityFrameworkCore;
using MovieService.Abstractions;
using MovieService.Models;

namespace MovieService.Data.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ServiceDbContext _context;

        public MovieRepository(ServiceDbContext context)
        {
            _context = context;
        }

        public async Task CreateMovieAsync(Movie movie)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }

            await _context.Movies.AddAsync(movie);
        }

        public async Task<Movie> GetMovieAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                throw new KeyNotFoundException($"Movie with Id: {id} wasn't found");
            }

            return movie;
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            var movies = await _context.Movies.ToListAsync();

            if (movies.Count == 0 && movies is null)
            {
                throw new KeyNotFoundException("No movies found");
            }

            return movies;
        }

        public async Task<bool> SaveChangesAsync()
        {
            var isChanged = await _context.SaveChangesAsync();

            return isChanged > 0;
        }
    }
}
