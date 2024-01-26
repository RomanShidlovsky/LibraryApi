using Application.Interfaces.Commands;
using Application.Wrappers;
using MediatR;

namespace Application.Features.BookFeatures.Commands.DeleteAuthor;

public sealed record DeleteBookAuthorCommand(
    int BookId,
    int AuthorId)
    : IRequest<Response>;
