using AutoMapper;
using MovieLibrary.Application.Configuration.Queries;
using MovieLibrary.Application.Dtos;
using MovieLibrary.Core.Interfaces.Repositories;

namespace MovieLibrary.Application.Movies.GetTopMoviesByTitle;

internal class GetTopMoviesByTitleQueryHandler(IMovieRepository movieRepository, IMapper mapper)
    : IQueryHandler<GetTopMoviesByTitleQuery, IEnumerable<MovieDto>>
{
    public async Task<IEnumerable<MovieDto>> Handle(GetTopMoviesByTitleQuery request, CancellationToken cancellationToken)
    {
        var movies = await movieRepository.GetTopByTitleAsync(request.Title, request.Limit, cancellationToken);
        var sortedMovies = movies.Sort(request.SortOption);

        var movieDtos = mapper.Map<IEnumerable<MovieDto>>(sortedMovies);
        return movieDtos;
    }
}