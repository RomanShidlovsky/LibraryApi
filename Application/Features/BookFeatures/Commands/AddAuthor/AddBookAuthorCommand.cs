using Application.Interfaces.Commands;

namespace Application.Features.BookFeatures.Commands.AddAuthor;

public sealed record AddBookAuthorCommand(
    int BookId,
    int AuthorId)
    : IUpdateCommand<bool>;