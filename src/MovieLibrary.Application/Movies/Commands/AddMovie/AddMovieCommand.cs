using MovieLibrary.Application.Configuration.Commands;
using MovieLibrary.Application.Dtos;
using MovieLibrary.Core.Models;

namespace MovieLibrary.Application.Movies.Commands.AddMovie;

public class AddMovieCommand : ICommand<MovieDto>
{
    public string Title { get; set; }
    public short Year { get; set; }
    public Genre Genre { get; set; }
}
