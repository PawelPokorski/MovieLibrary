using Microsoft.EntityFrameworkCore;
using MovieLibrary.Core.Models;
using MovieLibrary.Data.Configurations;

namespace MovieLibrary.Data.Context;

public class MovieContext (DbContextOptions<MovieContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<MovieRating> MovieRatings { get; set; }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("MoviesLibrary");

        modelBuilder.ApplyConfiguration(new MovieConfiguration());
        modelBuilder.ApplyConfiguration(new GenreConfiguration());
        modelBuilder.ApplyConfiguration(new MovieRatingConfiguration());
    }
}
