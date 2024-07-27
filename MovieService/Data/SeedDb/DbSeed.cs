using MovieService.Models;

namespace MovieService.Data.SeedDb
{
    public static class DbSeed
    {
        public static async Task SeedAsync(ServiceDbContext context, ILogger logger)
        {
            if (!context.Movies.Any())
            {
                logger.LogInformation("Seeding Data");

                var movies = new List<Movie>()
                {
                    new Movie { Title = "The Shawshank Redemption", Year = new DateTime(1994, 9, 14), Genre = "Drama", Director = "Frank Darabont" },
                    new Movie { Title = "The Godfather", Year = new DateTime(1972, 3, 24), Genre = "Crime", Director = "Francis Ford Coppola" },
                    new Movie { Title = "The Dark Knight", Year = new DateTime(2008, 7, 18), Genre = "Action", Director = "Christopher Nolan" },
                    new Movie { Title = "The Lord of the Rings: The Return of the King", Year = new DateTime(2003, 12, 17), Genre = "Adventure", Director = "Peter Jackson" },
                    new Movie { Title = "Pulp Fiction", Year = new DateTime(1994, 10, 14), Genre = "Crime", Director = "Quentin Tarantino" },
                    new Movie { Title = "Schindler's List", Year = new DateTime(1994, 2, 4), Genre = "Biography", Director = "Steven Spielberg" },
                    new Movie { Title = "Inception", Year = new DateTime(2010, 7, 16), Genre = "Action", Director = "Christopher Nolan" },
                    new Movie { Title = "Fight Club", Year = new DateTime(1999, 10, 15), Genre = "Drama", Director = "David Fincher" },
                    new Movie { Title = "Forrest Gump", Year = new DateTime(1994, 7, 6), Genre = "Drama", Director = "Robert Zemeckis" },
                    new Movie { Title = "The Lord of the Rings: The Fellowship of the Ring", Year = new DateTime(2001, 12, 19), Genre = "Adventure", Director = "Peter Jackson" }
                };

                await context.Movies.AddRangeAsync(movies);
            }
            else
            {
                logger.LogInformation("Database already seeded");
            }
        }
    }
}