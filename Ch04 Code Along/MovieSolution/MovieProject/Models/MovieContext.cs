using Microsoft.EntityFrameworkCore;
namespace MovieProject.Models
{
    public class MovieContext : DbContext
    {
        //DbSet<Movie> Movies is a property that represents the collection of all Movie objects
        public DbSet<Movie> Movies { get; set; } = null!;

        public MovieContext(DbContextOptions<MovieContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie() { MovieId = 1, Name = "The Godfather", Year = 1972, Rating = 5 },
                new Movie() { MovieId = 2, Name = "Casablanca", Year = 1942, Rating = 4 },
                new Movie() { MovieId = 3, Name = "The Matrix", Year = 1999, Rating = 4 }
                );
        }
    }
}
