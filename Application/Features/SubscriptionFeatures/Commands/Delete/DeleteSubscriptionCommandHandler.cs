using Application.DTOs.Subscription;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;

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
            return new NotFoundException(request.Id, typeof(Subscription));
        
        repository.Delete(subscription);
        await unitOfWork.SaveAsync(cancellationToken);

        return mapper.Map<SubscriptionViewModel>(subscription);
    }
}