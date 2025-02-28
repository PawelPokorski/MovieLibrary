using AutoMapper;
using MovieLibrary.Application.Configuration.Commands;
using MovieLibrary.Application.Dtos;
using MovieLibrary.Core.Interfaces;
using MovieLibrary.Core.Interfaces.Repositories;
using MovieLibrary.Core.Models;

namespace MovieLibrary.Application.Movies.Commands.AddMovie;

internal class AddMovieCommandHandler(IMovieRepository movieRepository, IMapper mapper, IUnitOfWork unitOfWork) : ICommandHandler<AddMovieCommand, MovieDto>
{
    public async Task<MovieDto> Handle(AddMovieCommand request, CancellationToken cancellationToken)
    {
        if(string.IsNullOrWhiteSpace(request.Title))
        {
            throw new ArgumentNullException("Title is required");
        }

        var movie = new Movie
        {
            Title = request.Title,
            Year = request.Year,
            AverageRating = 0.0m,
            Genre = request.Genre,
            MovieRatings = [],
        };

        movieRepository.Add(movie);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        var movieDto = mapper.Map<MovieDto>(movie);

        return movieDto;
    }
}