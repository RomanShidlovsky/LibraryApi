using Application.Auth;
using Application.DTOs.User;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Constants;
using Domain.Entities;

namespace Application.Features.UserFeatures.Commands.Register;

public class RegisterUserCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : ICreateCommandHandler<RegisterUserCommand, UserViewModel>
{
    public async Task<Response<UserViewModel>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<IUserRepository>();

        var existingUser = (await repository.GetAsync(u => u.Username == request.Username, cancellationToken))
            .LastOrDefault();

        if (existingUser != null)
            return new DuplicateException();

        var user = mapper.Map<User>(request);
        user.Password = HashHelper.GetPasswordHash(request.Password);

        var userRole =
            (await unitOfWork.GetRepository<IRoleRepository>().GetAsync(r => r.Name == Roles.User, cancellationToken))
            .LastOrDefault();

        if (userRole != null)
            user.Roles.Add(userRole);
        
        repository.Create(user);
        await unitOfWork.SaveAsync(cancellationToken);

        return mapper.Map<UserViewModel>(user);
    }
}