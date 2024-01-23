using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;

namespace Application.Features.SubscriptionFeatures.Commands.ReturnBook;

public class ReturnBookCommandHandler(IUnitOfWork unitOfWork) :
    IUpdateCommandHandler<ReturnBookCommand, bool>
{
    public async Task<Response<bool>> Handle(ReturnBookCommand request, CancellationToken cancellationToken)
    {
        var book = await unitOfWork.GetRepository<IBookRepository>().GetByIdAsync(request.BookId, cancellationToken);
        if (book == null)
            return new NotFoundException(request.BookId, typeof(Book));

        var subscription = book.Subscriptions.LastOrDefault();
        if (subscription == null || !subscription.IsActive)
            return new InvalidOperationException("Book already returned.");

        subscription.IsActive = false;
        await unitOfWork.SaveAsync(cancellationToken);

        return true;
    }
}