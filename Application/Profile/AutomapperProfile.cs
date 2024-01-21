using Application.DTOs.Genre;
using Domain.Entities;

namespace Application.Profile;

public class AutomapperProfile : AutoMapper.Profile
{
    public AutomapperProfile()
    {
        CreateMap<Genre, GenreViewModel>()
            .ReverseMap();
    }
}