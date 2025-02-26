using MovieLibrary.Application.Configuration.Queries;
using MovieLibrary.Application.Dtos;

namespace MovieLibrary.Application.Movies.GetMovieById;

public record GetMovieByIdQuery(Guid Id) : IQuery<MovieDto>;
