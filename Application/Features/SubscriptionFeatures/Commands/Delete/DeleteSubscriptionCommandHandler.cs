using Application.DTOs.Subscription;
using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Errors;

namespace Application.Features.SubscriptionFeatures.Commands.Delete;

public class DeleteSubscriptionCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : IDeleteCommandHandler<DeleteSubscriptionCommand, SubscriptionViewModel>
{
    public async Task<Response<SubscriptionViewModel>> Handle(DeleteSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<ISubscriptionRepository>();

        var subscription = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (subscription == null)
            return Response.Failure<SubscriptionViewModel>(DomainErrors.Subscription.SubscriptionNotFoundById);
        
        repository.Delete(subscription);
        await unitOfWork.SaveAsync(cancellationToken);

        return mapper.Map<SubscriptionViewModel>(subscription);
    }
}