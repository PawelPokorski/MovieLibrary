using MovieLibrary.Core.Models;

namespace MovieLibrary.Core.Interfaces.Repositories;

public interface IMovieRepository
{
    Task<Movie> GetByIdAsync(Guid id, CancellationToken cancellation = default);
    Task<IEnumerable<Movie>> GetByTitleAsync(string title, CancellationToken cancellation = default);
    Task<IEnumerable<Movie>> GetTopByTitleAsync(string title, int limit = 5, CancellationToken cancellation = default);
    Task<IEnumerable<Movie>> GetByYearAsync(int year, CancellationToken cancellation = default);
    Task<IEnumerable<Movie>> GetAllAsync(CancellationToken cancellation = default);


    void Add(Movie movie);
    void Update(Movie movie);
    void Delete(Movie movie);
}