using Application.DTOs.Author;
using Application.Interfaces.Queries;

namespace Application.Features.AuthorFeatures.Queries.GetAll;

public sealed record GetAllAuthorsQuery() : IQuery<IEnumerable<AuthorViewModel>>;