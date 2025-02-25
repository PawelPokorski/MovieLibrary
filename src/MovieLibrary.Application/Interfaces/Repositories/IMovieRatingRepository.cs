using MovieLibrary.Core.Models;

namespace MovieLibrary.Application.Interfaces.Repositories;

public interface IMovieRatingRepository
{
    Task<MovieRating> GetByIdAsync(Guid id);
    Task<IEnumerable<MovieRating>> GetAllAsync();
    Task AddAsync(MovieRating movieRating);
    Task UpdateAsync(MovieRating movieRating);
    Task DeleteAsync(Guid id);
}