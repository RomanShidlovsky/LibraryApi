using Application.DTOs.Book;
using Application.Interfaces.Queries;

namespace Application.Features.BookFeatures.Queries.GetByISBN;

public sealed record GetBookByIsbnQuery(string ISBN) : ISingleQuery<BookViewModel>;