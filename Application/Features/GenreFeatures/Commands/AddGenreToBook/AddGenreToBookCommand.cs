using Application.Wrappers;
using MediatR;

namespace Application.Features.GenreFeatures.Commands.AddGenreToBook;

public sealed record AddGenreToBookCommand(
    int BookId,
    int GenreId)
    : IRequest<Response>;