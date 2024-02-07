using Application.Wrappers;
using MediatR;

namespace Application.Features.GenreFeatures.Commands.DeleteGenreFromBook;

public sealed record DeleteGenreFromBookCommand(
    int BookId,
    int GenreId)
    : IRequest<Response>;