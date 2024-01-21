using Application.DTOs.Genre;
using Application.Interfaces.Queries;

namespace Application.Features.GenreFeatures.Queries.GetAll;

public sealed record GetAllGenresQuery(): IQuery<IEnumerable<GenreViewModel>>;