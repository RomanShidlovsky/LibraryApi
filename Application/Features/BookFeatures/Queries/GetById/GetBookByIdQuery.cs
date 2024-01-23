using Application.DTOs.Book;
using Application.Interfaces.Queries;

namespace Application.Features.BookFeatures.Queries.GetById;

public sealed record GetBookByIdQuery(int Id) : ISingleQuery<BookViewModel>;
