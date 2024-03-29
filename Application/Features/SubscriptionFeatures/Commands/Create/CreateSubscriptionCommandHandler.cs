﻿using Application.DTOs.Subscription;
using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using Domain.Errors;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.SubscriptionFeatures.Commands.Create;

public class CreateSubscriptionCommandHandler(
    IUnitOfWork unitOfWork,
    UserManager<User> userManager,
    IMapper mapper)
    : ICreateCommandHandler<CreateSubscriptionCommand, SubscriptionViewModel>
{
    public async Task<Response<SubscriptionViewModel>> Handle(CreateSubscriptionCommand request,
        CancellationToken cancellationToken)
    {
        var book = await unitOfWork.GetRepository<IBookRepository>().GetByIdAsync(request.BookId, cancellationToken);
        if (book == null)
            return Response.Failure<SubscriptionViewModel>(DomainErrors.Book.BookNotFoundById);

        if (book.Subscriptions.Any(s => s.IsActive))
            return Response.Failure<SubscriptionViewModel>(DomainErrors.Subscription.BookAlreadyTaken);

        var user = await userManager.FindByIdAsync(request.UserId.ToString());
        if (user == null)
            return Response.Failure<SubscriptionViewModel>(DomainErrors.User.UserNotFoundById);

        var subscription = mapper.Map<Subscription>(request);
        subscription.IsActive = true;

        unitOfWork.GetRepository<ISubscriptionRepository>().Create(subscription);
        
        book.Subscriptions.Add(subscription);
        user.Subscriptions.Add(subscription);

        await unitOfWork.SaveAsync(cancellationToken);

        return mapper.Map<SubscriptionViewModel>(subscription);
    }
}