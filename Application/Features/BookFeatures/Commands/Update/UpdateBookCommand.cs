using Application.DTOs.Book;
using Application.Interfaces.Commands;

namespace Application.Features.BookFeatures.Commands.Update;

public sealed record UpdateBookCommand(
    int Id,
    string Title,
    string? Description)
    : IUpdateCommand<BookViewModel>;