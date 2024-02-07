using Application.Wrappers;
using MediatR;

namespace Application.Features.AuthorFeatures.Commands.DeleteAuthorFromBook;

public sealed record DeleteAuthorFromBookCommand(
    int BookId,
    int AuthorId)
    : IRequest<Response>;
