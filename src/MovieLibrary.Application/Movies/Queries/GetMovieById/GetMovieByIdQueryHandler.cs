using AutoMapper;
using MovieLibrary.Application.Configuration.Queries;
using MovieLibrary.Application.Dtos;
using MovieLibrary.Core.Interfaces.Repositories;

namespace MovieLibrary.Application.Movies.Queries.GetMovieById;

internal class GetMovieByIdQueryHandler(IMovieRepository movieRepository, IMapper mapper)
    : IQueryHandler<GetMovieByIdQuery, MovieDto>
{
    public async Task<MovieDto> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
    {
        var movie = await movieRepository.GetByIdAsync(request.Id, cancellationToken);

        var movieDto = mapper.Map<MovieDto>(movie);

        return movieDto;
    }
}