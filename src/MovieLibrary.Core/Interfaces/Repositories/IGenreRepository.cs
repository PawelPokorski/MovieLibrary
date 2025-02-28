using MovieLibrary.Core.Models;

namespace MovieLibrary.Core.Interfaces.Repositories;

public interface IGenreRepository
{
    Task<Genre> GetByIdAsync(Guid id, CancellationToken cancellation = default);
    Task<Genre> GetByNameAsync(string name, CancellationToken cancellation = default);
    Task<IEnumerable<Genre>> GetAllAsync(CancellationToken cancellation = default);

    void Add(string name);
    void Update(Genre genre);
    void Delete(Genre genre);
}
