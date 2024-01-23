using Application.DTOs.Book;
using Application.Interfaces.Commands;

namespace Application.Features.BookFeatures.Commands.Delete;

public sealed record DeleteBookCommand(int Id) : IDeleteCommand<BookViewModel>;