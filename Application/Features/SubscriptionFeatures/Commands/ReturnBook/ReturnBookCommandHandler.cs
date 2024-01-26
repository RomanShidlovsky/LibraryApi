using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Errors;
using MediatR;

namespace Application.Features.SubscriptionFeatures.Commands.ReturnBook;

public class ReturnBookCommandHandler(IUnitOfWork unitOfWork) :
    IRequestHandler<ReturnBookCommand, Response>
{
    public async Task<Response> Handle(ReturnBookCommand request, CancellationToken cancellationToken)
    {
        var book = await unitOfWork.GetRepository<IBookRepository>().GetByIdAsync(request.BookId, cancellationToken);
        if (book == null)
            return Response.Failure(DomainErrors.Book.BookNotFoundById);

        var subscription = book.Subscriptions.LastOrDefault();
        if (subscription == null || !subscription.IsActive)
            return Response.Failure(DomainErrors.Subscription.BookAlreadyReturned);

        subscription.ReturnBook();
        await unitOfWork.SaveAsync(cancellationToken);

        return Response.Success();
    }
}