using Application.DTOs.Author;
using Application.Features.AuthorFeatures.Commands.Create;
using Application.Features.AuthorFeatures.Commands.Update;
using Domain.Entities;

namespace Application.Profile;

public class AuthorMapper : AutoMapper.Profile
{
    public AuthorMapper()
    {
        CreateMap<CreateAuthorCommand, Author>();
        CreateMap<UpdateAuthorCommand, Author>();
        CreateMap<Author, AuthorViewModel>()
            .ReverseMap();
    }
}