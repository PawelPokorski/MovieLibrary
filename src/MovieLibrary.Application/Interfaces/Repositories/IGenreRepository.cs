using MovieLibrary.Core.Models;

namespace MovieLibrary.Application.Interfaces.Repositories;

public interface IGenreRepository
{
    Task<Genre> GetByIdAsync(Guid id);
    Task<IEnumerable<Genre>> GetAllAsync();
    Task AddAsync(Genre genre);
    Task UpdateAsync(Genre genre);
    Task DeleteAsync(Guid id);
}
