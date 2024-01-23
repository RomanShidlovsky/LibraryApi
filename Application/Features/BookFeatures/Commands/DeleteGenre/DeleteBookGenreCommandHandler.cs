using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;

namespace Application.Features.BookFeatures.Commands.DeleteGenre;

public class DeleteBookGenreCommandHandler(IUnitOfWork unitOfWork)
    : IUpdateCommandHandler<DeleteBookGenreCommand, bool>
{
    public async Task<Response<bool>> Handle(DeleteBookGenreCommand request, CancellationToken cancellationToken)
    {
        var result = await unitOfWork.GetRepository<IBookRepository>()
            .DeleteGenreAsync(request.BookId, request.GenreId, cancellationToken);

        await unitOfWork.SaveAsync(cancellationToken);

        return result;
    }
}