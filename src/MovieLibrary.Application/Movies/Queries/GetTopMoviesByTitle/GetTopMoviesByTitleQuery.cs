using MovieLibrary.Application.Configuration.Queries;
using MovieLibrary.Application.Dtos;
using MovieLibrary.Application.Enums;

namespace MovieLibrary.Application.Movies.Queries.GetTopMoviesByTitle;

public record GetTopMoviesByTitleQuery(string Title, int Limit, MovieSortOption SortOption = MovieSortOption.AverageRatingDescending) : IQuery<IEnumerable<MovieDto>>;
