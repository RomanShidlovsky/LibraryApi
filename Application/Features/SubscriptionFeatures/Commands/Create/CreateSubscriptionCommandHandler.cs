using Application.DTOs.Subscription;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.SubscriptionFeatures.Commands.Create;

public class CreateSubscriptionCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : ICreateCommandHandler<CreateSubscriptionCommand, SubscriptionViewModel>
{
    public async Task<Response<SubscriptionViewModel>> Handle(CreateSubscriptionCommand request,
        CancellationToken cancellationToken)
    {
        var book = await unitOfWork.GetRepository<IBookRepository>().GetByIdAsync(request.BookId, cancellationToken);
        if (book == null)
            return new NotFoundException(request.BookId, typeof(Book));

        if (book.Subscriptions.Any(s => s.IsActive))
            return new InvalidOperationException("Book is already taken.");
        
        var user = await unitOfWork.GetRepository<IUserRepository>().GetByIdAsync(request.UserId, cancellationToken);
        if (user == null)
            return new NotFoundException(request.UserId, typeof(User));

        var subscription = mapper.Map<Subscription>(request);

        unitOfWork.GetRepository<ISubscriptionRepository>().Create(subscription);
        
        book.Subscriptions.Add(subscription);
        user.Subscriptions.Add(subscription);

        await unitOfWork.SaveAsync(cancellationToken);

        return mapper.Map<SubscriptionViewModel>(subscription);
    }
}