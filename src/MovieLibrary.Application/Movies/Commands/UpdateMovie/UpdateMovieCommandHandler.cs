using AutoMapper;
using MovieLibrary.Application.Configuration.Commands;
using MovieLibrary.Core.Interfaces;
using MovieLibrary.Core.Interfaces.Repositories;

namespace MovieLibrary.Application.Movies.Commands.UpdateMovie;

internal class UpdateMovieCommandHandler(IMovieRepository movieRepository, IGenreRepository genreRepository, IUnitOfWork unitOfWork) : ICommandHandler<UpdateMovieCommand>
{
    public async Task Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await movieRepository.GetByIdAsync(request.MovieDto.Id);

        if(movie != null)
        {
            movie.Title = request.MovieDto.Title;
            movie.Year = request.MovieDto.Year;
            movie.Genre = await genreRepository.GetByNameAsync(request.MovieDto.Genre, cancellationToken);

            movieRepository.Update(movie);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}