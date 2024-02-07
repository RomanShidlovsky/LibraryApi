using Application.DTOs.Book;
using Application.Interfaces.Commands;

namespace Application.Features.BookFeatures.Commands.Update;

public sealed record UpdateBookCommand : IUpdateCommand<BookViewModel>
{
    public int Id { get; init; }
    public string Title { get; init; }
    public string? Description { get; init; }

    public UpdateBookCommand(UpdateBookDto dto)
    {
        Id = dto.Id;
        Title = dto.Title;
        Description = dto.Description;
    }
}