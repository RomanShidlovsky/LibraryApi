using Application.DTOs.Subscription;
using Domain.Entities;

namespace Application.Profile;

public class SubscriptionMapper : AutoMapper.Profile
{
    public SubscriptionMapper()
    {
        CreateMap<Subscription, SubscriptionViewModel>()
            .ReverseMap();
    }
}