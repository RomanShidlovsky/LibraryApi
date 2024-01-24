using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;

namespace Application.Features.BookFeatures.Commands.AddAuthor;

public class AddBookAuthorCommandHandler(IUnitOfWork unitOfWork)
    : IUpdateCommandHandler<AddBookAuthorCommand, bool>
{
    public async Task<Response<bool>> Handle(AddBookAuthorCommand request, CancellationToken cancellationToken)
    {
        var result = await unitOfWork.GetRepository<IBookRepository>()
            .AddAuthorAsync(request.BookId, request.AuthorId, cancellationToken);

        await unitOfWork.SaveAsync(cancellationToken);

        return result;
    }
}