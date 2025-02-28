using MovieLibrary.Application.Configuration.Commands;
using MovieLibrary.Core.Interfaces;
using MovieLibrary.Core.Interfaces.Repositories;

namespace MovieLibrary.Application.Movies.Commands.RemoveMovie;

internal class RemoveMovieCommandHandler(IMovieRepository movieRepository, IUnitOfWork unitOfWork) : ICommandHandler<RemoveMovieCommand>
{
    public async Task Handle(RemoveMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await movieRepository.GetByIdAsync(request.MovieId, cancellationToken);

        if(movie != null)
        {
            movieRepository.Delete(movie);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}