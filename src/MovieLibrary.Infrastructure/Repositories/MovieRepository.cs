using Microsoft.EntityFrameworkCore;
using MovieLibrary.Core.Interfaces.Repositories;
using MovieLibrary.Core.Models;
using MovieLibrary.Data.Context;

namespace MovieLibrary.Infrastructure.Repositories;

public class MovieRepository(MovieContext context) : IMovieRepository
{
    public async Task<Movie?> GetByIdAsync(Guid id, CancellationToken cancellation = default)
    {
        return await context.Movies.SingleOrDefaultAsync(m => m.Id == id, cancellation);
    }

    public async Task<IEnumerable<Movie>> GetAllAsync(CancellationToken cancellation = default)
    {
        return await context.Movies.AsNoTracking().ToListAsync(cancellation);
    }

    public void Add(Movie movie)
    {
        context.Movies.Add(movie);
    }

    public void Update(Movie movie)
    {
        context.Movies.Update(movie);
    }

    public void Delete(Movie movie)
    {
        context.Movies.Remove(movie);
    }
}