using MovieLibrary.Application.Configuration.Commands;

namespace MovieLibrary.Application.Movies.Commands.RemoveMovie;

public record RemoveMovieCommand(Guid MovieId) : ICommand;