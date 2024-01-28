using Application.DTOs.Genre;
using Application.Features.GenreFeatures.Commands.Create;
using Domain.Entities;

namespace Application.Profile;

public class GenreMapper : AutoMapper.Profile
{
    public GenreMapper()
    {
        CreateMap<CreateGenreCommand, Genre>();
        CreateMap<Genre, GenreViewModel>()
            .ReverseMap();
    }
}