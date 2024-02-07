using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Errors;
using Domain.Extensions;
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
        
        if (!book.CanReturn())
            return Response.Failure(DomainErrors.Subscription.BookAlreadyReturned);

        var subscriptionId = book.Subscriptions.Last().Id;
        await unitOfWork.GetRepository<ISubscriptionRepository>().ReturnBook(subscriptionId, cancellationToken);
        await unitOfWork.SaveAsync(cancellationToken);

        return Response.Success();
    }
}