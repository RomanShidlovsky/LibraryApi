using Application.Interfaces.Commands;
using Application.Wrappers;
using MediatR;

namespace Application.Features.BookFeatures.Commands.AddAuthor;

public sealed record AddBookAuthorCommand(
    int BookId,
    int AuthorId)
    : IRequest<Response>;