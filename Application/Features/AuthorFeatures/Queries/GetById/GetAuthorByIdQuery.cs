using Application.DTOs.Author;
using Application.Interfaces.Queries;

namespace Application.Features.AuthorFeatures.Queries.GetById;

public sealed record GetAuthorByIdQuery(int Id) : ISingleQuery<AuthorViewModel>;
