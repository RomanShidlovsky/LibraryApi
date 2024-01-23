using Application.DTOs.Book;
using Application.Interfaces.Queries;

namespace Application.Features.BookFeatures.Queries.GetAll;

public sealed record GetAllBooksQuery() : IQuery<IEnumerable<BookViewModel>>;