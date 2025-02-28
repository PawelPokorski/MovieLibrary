using AutoMapper;
using MovieLibrary.Application.Dtos;
using MovieLibrary.Core.Models;

namespace MovieLibrary.Application.Configuration.Mappings;

public class MovieRatingMappingProfile : Profile
{
    public MovieRatingMappingProfile()
    {
        CreateMap<MovieRating, MovieRatingDto>();
    }
}