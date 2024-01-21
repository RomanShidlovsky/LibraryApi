using Application.DTOs.Genre;
using Application.Interfaces.Commands;

namespace Application.Features.GenreFeatures.Commands.Delete;

public sealed record DeleteGenreCommand(int Id) : IDeleteCommand<GenreViewModel>;