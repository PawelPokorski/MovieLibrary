using Microsoft.EntityFrameworkCore;
using MovieLibrary.Core.Interfaces.Repositories;
using MovieLibrary.Core.Models;
using MovieLibrary.Data.Context;

namespace MovieLibrary.Infrastructure.Repositories;

public class MovieRepository(MovieContext context) : IMovieRepository
{
    public async Task<Movie?> GetByIdAsync(Guid id, CancellationToken cancellation = default)
    {
        return await context.Movies
            .Include(m => m.Genre)
            .FirstOrDefaultAsync(m => m.Id == id, cancellation);
    }

    public async Task<IEnumerable<Movie>> GetByTitleAsync(string title, CancellationToken cancellation = default)
    {
        return await context.Movies
            .Where(m => m.Title.Contains(title, StringComparison.CurrentCultureIgnoreCase))
            .ToListAsync(cancellation);
    }

    public async Task<IEnumerable<Movie>> GetTopByTitleAsync(string title, int limit = 5, CancellationToken cancellation = default)
    {
        return await context.Movies
            .Where(m => m.Title.Contains(title, StringComparison.CurrentCultureIgnoreCase))
            .OrderByDescending(m => m.AverageRating)
            .Take(limit)
            .ToListAsync(cancellation);
    }

    public async Task<IEnumerable<Movie>> GetByYearAsync(int year, CancellationToken cancellation = default)
    {
        return await context.Movies
            .Where(m => m.Year == year)
            .ToListAsync(cancellation);
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