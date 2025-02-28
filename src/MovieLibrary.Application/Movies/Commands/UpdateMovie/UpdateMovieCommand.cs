using MovieLibrary.Application.Configuration.Commands;
using MovieLibrary.Application.Dtos;

namespace MovieLibrary.Application.Movies.Commands.UpdateMovie;

public record UpdateMovieCommand(MovieDto MovieDto) : ICommand;