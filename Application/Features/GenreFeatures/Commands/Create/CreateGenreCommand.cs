using Application.DTOs.Genre;
using Application.Interfaces.Commands;
using Domain.Entities;

namespace Application.Features.GenreFeatures.Commands.Create;

public sealed record CreateGenreCommand(string Name) :ICreateCommand<GenreViewModel>;