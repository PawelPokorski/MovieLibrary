using MovieLibrary.Application.Configuration.Queries;
using MovieLibrary.Application.Dtos;
using MovieLibrary.Application.Enums;

namespace MovieLibrary.Application.Movies.GetMovies;

public record GetMoviesQuery(MovieSortOption SortOption = MovieSortOption.AverageRatingDescending) : IQuery<IEnumerable<MovieDto>>;