using Application.DTOs.User;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.UserFeatures.Commands.Update;

public class UpdateUserCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : IUpdateCommandHandler<UpdateUserCommand, UserViewModel>
{
    public async Task<Response<UserViewModel>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<IUserRepository>();

        var existingUser = await repository.GetByUsernameAsync(request.Username, cancellationToken);
        if (existingUser != null)
            return new DuplicateException($"User with username {request.Username} already exists.");

        var user = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (user == null)
            return new NotFoundException(request.Id, typeof(User));

        user.Username = request.Username;
        user.Email = request.Email;

        await unitOfWork.SaveAsync(cancellationToken);

        return mapper.Map<UserViewModel>(user);
    }
}