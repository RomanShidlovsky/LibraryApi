using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;

namespace Application.Features.BookFeatures.Commands.AddGenre;

public class AddBookGenreCommandHandler(IUnitOfWork unitOfWork)
    : IUpdateCommandHandler<AddBookGenreCommand, bool>
{
    public async Task<Response<bool>> Handle(AddBookGenreCommand request, CancellationToken cancellationToken)
    {
        var result = await unitOfWork.GetRepository<IBookRepository>()
            .AddGenreAsync(request.BookId, request.GenreId, cancellationToken);

        await unitOfWork.SaveAsync(cancellationToken);

        return result;
    }
}