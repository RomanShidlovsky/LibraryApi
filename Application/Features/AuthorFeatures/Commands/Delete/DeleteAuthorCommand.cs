using Application.DTOs.Author;
using Application.Interfaces.Commands;

namespace Application.Features.AuthorFeatures.Commands.Delete;

public sealed record DeleteAuthorCommand(int Id) : IDeleteCommand<AuthorViewModel>;