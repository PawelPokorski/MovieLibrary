using MovieLibrary.Application.Configuration.Queries;
using MovieLibrary.Application.Dtos;
using MovieLibrary.Application.Enums;

namespace MovieLibrary.Application.Movies.GetMoviesByTitle;

public record GetMoviesByTitleQuery(string Title, MovieSortOption SortOption = MovieSortOption.AverageRatingDescending) : IQuery<IEnumerable<MovieDto>>;