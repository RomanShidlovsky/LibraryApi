using Application.DTOs.Genre;
using Application.Interfaces.Commands;
using Domain.Entities;

namespace Application.Features.GenreFeatures.Commands.Create;

public sealed record CreateGenreCommand : ICreateCommand<GenreViewModel>
{
    public string Name { get; init; }

    public CreateGenreCommand(CreateGenreDto dto)
    {
        Name = dto.Name;
    }
}