using Application.DTOs.User;
using Application.Features.UserFeatures.Commands.Register;
using Domain.Entities;

namespace Application.Profile;

public class UserMapper : AutoMapper.Profile
{
    public UserMapper()
    {
        CreateMap<RegisterUserCommand, User>();
        CreateMap<User, UserViewModel>()
            .ReverseMap();
    }
}