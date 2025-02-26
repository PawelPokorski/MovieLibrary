using Microsoft.EntityFrameworkCore;
using MovieLibrary.Core.Interfaces.Repositories;
using MovieLibrary.Core.Models;
using MovieLibrary.Data.Context;

namespace MovieLibrary.Infrastructure.Repositories;

public class MovieRatingRepository(MovieContext context) : IMovieRatingRepository
{
    public async Task<MovieRating?> GetByIdAsync(Guid id, CancellationToken cancellation = default)
    {
        return await context.MovieRatings.FindAsync(id, cancellation);
    }

    public async Task<IEnumerable<MovieRating>> GetAllAsync(CancellationToken cancellation = default)
    {
        return await context.MovieRatings.AsNoTracking().ToListAsync(cancellation);
    }

    public void Add(MovieRating movieRating)
    {
        context.MovieRatings.Add(movieRating);
    }

    public void Update(MovieRating movieRating)
    {
        context.MovieRatings.Update(movieRating);
    }

    public void Delete(MovieRating movieRating)
    {
        context.MovieRatings.Remove(movieRating);
    }
}