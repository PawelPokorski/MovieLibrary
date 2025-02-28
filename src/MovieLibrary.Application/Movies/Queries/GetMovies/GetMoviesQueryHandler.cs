using AutoMapper;
using MovieLibrary.Application.Configuration.Queries;
using MovieLibrary.Application.Dtos;
using MovieLibrary.Core.Interfaces.Repositories;

namespace MovieLibrary.Application.Movies.Queries.GetMovies;

internal class GetMoviesQueryHandler(IMovieRepository movieRepository, IMapper mapper)
    : IQueryHandler<GetMoviesQuery, IEnumerable<MovieDto>>
{
    public async Task<IEnumerable<MovieDto>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
    {
        var movies = await movieRepository.GetAllAsync(cancellationToken);
        var sortedMovies = movies.Sort(request.SortOption);

        var movieDtos = mapper.Map<IEnumerable<MovieDto>>(sortedMovies);
        return movieDtos;
    }
}