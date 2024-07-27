using Microsoft.EntityFrameworkCore;

namespace MovieService.Data
{
    public sealed class ServiceDbContext : DbContext
    {
        public ServiceDbContext(DbContextOptions<ServiceDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
