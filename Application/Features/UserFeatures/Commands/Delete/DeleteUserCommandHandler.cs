using Application.DTOs.User;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.UserFeatures.Commands.Delete;

public class DeleteUserCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : IDeleteCommandHandler<DeleteUserCommand, UserViewModel>
{
    public async Task<Response<UserViewModel>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<IUserRepository>();

        var user = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (user == null)
            return new NotFoundException(request.Id, typeof(User));
        
        repository.Delete(user);
        await unitOfWork.SaveAsync(cancellationToken);

        return mapper.Map<UserViewModel>(user);
    }
}