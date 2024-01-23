using Application.Interfaces.Commands;

namespace Application.Features.BookFeatures.Commands.AddGenre;

public sealed record AddBookGenreCommand(
    int BookId,
    int GenreId)
    : IUpdateCommand<bool>;