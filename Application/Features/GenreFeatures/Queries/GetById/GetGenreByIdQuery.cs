using Application.DTOs.Genre;
using Application.Interfaces.Queries;

namespace Application.Features.GenreFeatures.Queries.GetById;

public sealed record GetGenreByIdQuery(int Id) : ISingleQuery<GenreViewModel>;