using Application.DTOs.Genre;
using Application.Interfaces.Commands;

namespace Application.Features.GenreFeatures.Commands.Update;

public sealed record UpdateGenreCommand(
    int Id,
    string Name) 
    : IUpdateCommand<GenreViewModel>;