using Application.Features.BookFeatures.Commands.Delete;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;

namespace Application.Features.BookFeatures.Commands.DeleteAuthor;

public class DeleteBookAuthorCommandHandler(IUnitOfWork unitOfWork)
    : IUpdateCommandHandler<DeleteBookAuthorCommand, bool>
{
    public async Task<Response<bool>> Handle(DeleteBookAuthorCommand request, CancellationToken cancellationToken)
    {
        var result = await unitOfWork.GetRepository<IBookRepository>()
            .DeleteAuthorAsync(request.BookId, request.AuthorId, cancellationToken);

        await unitOfWork.SaveAsync(cancellationToken);

        return result;
    }
}