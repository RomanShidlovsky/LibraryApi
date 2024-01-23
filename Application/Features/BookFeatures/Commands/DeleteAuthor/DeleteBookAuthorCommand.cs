using Application.Interfaces.Commands;

namespace Application.Features.BookFeatures.Commands.DeleteAuthor;

public sealed record DeleteBookAuthorCommand(
    int BookId,
    int AuthorId)
    : IUpdateCommand<bool>;
