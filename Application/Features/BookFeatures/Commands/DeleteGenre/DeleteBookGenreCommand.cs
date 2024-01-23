using Application.Interfaces.Commands;

namespace Application.Features.BookFeatures.Commands.DeleteGenre;

public sealed record DeleteBookGenreCommand(
    int BookId,
    int GenreId)
    : IUpdateCommand<bool>;