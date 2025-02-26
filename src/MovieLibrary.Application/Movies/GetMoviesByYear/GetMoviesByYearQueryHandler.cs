using AutoMapper;
using MovieLibrary.Application.Configuration.Queries;
using MovieLibrary.Application.Dtos;
using MovieLibrary.Core.Interfaces.Repositories;

namespace MovieLibrary.Application.Movies.GetMoviesByYear;

internal class GetMoviesByYearQueryHandler(IMovieRepository movieRepository, IMapper mapper)
    : IQueryHandler<GetMoviesByYearQuery, IEnumerable<MovieDto>>
{
    public async Task<IEnumerable<MovieDto>> Handle(GetMoviesByYearQuery request, CancellationToken cancellationToken)
    {
        var movies = await movieRepository.GetByYearAsync(request.Year, cancellationToken);
        var sortedMovies = movies.Sort(request.SortOption);

        var movieDtos = mapper.Map<IEnumerable<MovieDto>>(sortedMovies);
        return movieDtos;
    }
}