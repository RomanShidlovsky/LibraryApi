using Application.DTOs.Book;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.BookFeatures.Commands.Create;

public class CreateBookCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : ICreateCommandHandler<CreateBookCommand, BookViewModel>
{
    public async Task<Response<BookViewModel>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<IBookRepository>();
        var isbn = request.ISBN.Replace("-", "");

        var existingBook =  await repository.GetByIsbnAsync(isbn, cancellationToken);
        if (existingBook != null)
            return new DuplicateException();
        
        var genres = await unitOfWork.GetRepository<IGenreRepository>()
            .GetAsync(g => request.GenreIds.Contains(g.Id), cancellationToken);

        var authors = await unitOfWork.GetRepository<IAuthorRepository>()
            .GetAsync(a => request.AuthorIds.Contains(a.Id), cancellationToken);

        var book = mapper.Map<Book>(request);

        book.ISBN = isbn;
        book.Genres = genres;
        book.Authors = authors;
        
        repository.Create(book);
        await unitOfWork.SaveAsync(cancellationToken);

        return mapper.Map<BookViewModel>(book);
    }
}