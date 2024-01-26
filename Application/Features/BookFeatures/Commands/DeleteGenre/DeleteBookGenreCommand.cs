using Application.Interfaces.Commands;
using Application.Wrappers;
using MediatR;

namespace Application.Features.BookFeatures.Commands.DeleteGenre;

public sealed record DeleteBookGenreCommand(
    int BookId,
    int GenreId)
    : IRequest<Response>;