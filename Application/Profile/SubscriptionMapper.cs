using Application.DTOs.Subscription;
using Application.Features.SubscriptionFeatures.Commands.Create;
using Domain.Entities;

namespace Application.Profile;

public class SubscriptionMapper : AutoMapper.Profile
{
    public SubscriptionMapper()
    {
        CreateMap<CreateSubscriptionCommand, Subscription>();
        CreateMap<Subscription, SubscriptionViewModel>()
            .ReverseMap();
    }
}