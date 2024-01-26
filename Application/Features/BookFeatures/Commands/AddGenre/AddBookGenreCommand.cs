using Application.Interfaces.Commands;
using Application.Wrappers;
using MediatR;

namespace Application.Features.BookFeatures.Commands.AddGenre;

public sealed record AddBookGenreCommand(
    int BookId,
    int GenreId)
    : IRequest<Response>;