using Application.Wrappers;
using MediatR;

namespace Application.Features.AuthorFeatures.Commands.AddAuthorToBook;

public sealed record AddAuthorToBook(
    int BookId,
    int AuthorId)
    : IRequest<Response>;