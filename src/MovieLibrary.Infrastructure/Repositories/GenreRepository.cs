using Microsoft.EntityFrameworkCore;
using MovieLibrary.Core.Interfaces.Repositories;
using MovieLibrary.Core.Models;
using MovieLibrary.Data.Context;

namespace MovieLibrary.Infrastructure.Repositories;

public class GenreRepository(MovieContext context) : IGenreRepository
{
    public async Task<Genre?> GetByIdAsync(Guid id, CancellationToken cancellation = default)
    {
        return await context.Genres.FindAsync(id, cancellation);
    }

    public async Task<IEnumerable<Genre>> GetAllAsync(CancellationToken cancellation = default)
    {
        return await context.Genres.AsNoTracking().ToListAsync(cancellation);
    }

    public void Add(Genre genre)
    {
        context.Genres.Add(genre);
    }

    public void Update(Genre genre)
    {
        context.Genres.Update(genre);
    }

    public void Delete(Genre genre)
    {
        context.Genres.Remove(genre);
    }
}