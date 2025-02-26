using AutoMapper;
using MovieLibrary.Application.Dtos;
using MovieLibrary.Core.Extensions;
using MovieLibrary.Core.Models;

namespace MovieLibrary.Application.Configuration.Mappings;

public class MovieMappingProfile : Profile
{
    public MovieMappingProfile()
    {
        CreateMap<Movie, MovieDto>()
            .ForMember(dest => dest.AverageRating, conf => conf.MapFrom(model => model.MovieRatings.GetAverageRating()))
            .ForMember(dest => dest.Genre, conf => conf.MapFrom(model => model.Genre != null ? model.Genre.Name : null));
            //.ForMember(dest => dest.Director, conf => conf.MapFrom(model => model.Director != null ? model.Director.ToString() : null))
    }
}