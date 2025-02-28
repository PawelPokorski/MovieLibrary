using AutoMapper;
using MovieLibrary.Application.Configuration.Queries;
using MovieLibrary.Application.Dtos;
using MovieLibrary.Core.Interfaces.Repositories;

namespace MovieLibrary.Application.Movies.Queries.GetMoviesByTitle;

internal class GetMoviesByTitleQueryHandler(IMovieRepository movieRepository, IMapper mapper)
    : IQueryHandler<GetMoviesByTitleQuery, IEnumerable<MovieDto>>
{
    public async Task<IEnumerable<MovieDto>> Handle(GetMoviesByTitleQuery request, CancellationToken cancellationToken)
    {
        var movies = await movieRepository.GetByTitleAsync(request.Title, cancellationToken);
        var sortedMovies = movies.Sort(request.SortOption);

        var movieDtos = mapper.Map<IEnumerable<MovieDto>>(sortedMovies);
        return movieDtos;
    }
}