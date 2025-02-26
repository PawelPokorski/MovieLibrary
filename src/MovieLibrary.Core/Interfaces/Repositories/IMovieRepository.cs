using MovieLibrary.Core.Models;

namespace MovieLibrary.Core.Interfaces.Repositories;

public interface IMovieRepository
{
    Task<Movie> GetByIdAsync(Guid id, CancellationToken cancellation = default);
    Task<IEnumerable<Movie>> GetAllAsync(CancellationToken cancellation = default);

    void Add(Movie movie);
    void Update(Movie movie);
    void Delete(Movie movie);
}