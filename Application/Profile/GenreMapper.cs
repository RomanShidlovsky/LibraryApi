using Application.DTOs.Genre;
using Application.Features.GenreFeatures.Commands.Create;
using Application.Features.GenreFeatures.Commands.Update;
using Domain.Entities;

namespace Application.Profile;

public class GenreMapper : AutoMapper.Profile
{
    public GenreMapper()
    {
        CreateMap<CreateGenreCommand, Genre>();
        CreateMap<UpdateGenreCommand, Genre>();
        CreateMap<Genre, GenreViewModel>()
            .ReverseMap();
    }
}