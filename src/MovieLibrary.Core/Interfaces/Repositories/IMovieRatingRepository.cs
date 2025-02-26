using MovieLibrary.Core.Models;

namespace MovieLibrary.Core.Interfaces.Repositories;

public interface IMovieRatingRepository
{
    Task<MovieRating> GetByIdAsync(Guid id, CancellationToken cancellation = default);
    Task<IEnumerable<MovieRating>> GetAllAsync(CancellationToken cancellation = default);

    void Add(MovieRating movieRating);
    void Update(MovieRating movieRating);
    void Delete(MovieRating movieRating);
}