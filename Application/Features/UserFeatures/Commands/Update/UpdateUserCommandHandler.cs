using Application.DTOs.User;
using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Errors;

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
            return Response.Failure<UserViewModel>(DomainErrors.User.UsernameConflict);

        var user = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (user == null)
            return Response.Failure<UserViewModel>(DomainErrors.User.UserNotFoundById);

        user.Username = request.Username;
        user.Email = request.Email;

        await unitOfWork.SaveAsync(cancellationToken);

        return mapper.Map<UserViewModel>(user);
    }
}