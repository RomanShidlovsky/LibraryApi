using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Errors;
using MediatR;

namespace Application.Features.UserFeatures.Commands.DeleteRole;

public class DeleteUserRoleCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteUserRoleCommand, Response>
{
    public async Task<Response> Handle(DeleteUserRoleCommand request, CancellationToken cancellationToken)
    {
        var succeeded = await unitOfWork.GetRepository<IUserRepository>()
            .DeleteRoleAsync(request.UserId, request.RoleId, cancellationToken);

        if (succeeded)
        {
            await unitOfWork.SaveAsync(cancellationToken);
        }

        return succeeded
            ? Response.Success()
            : Response.Failure(DomainErrors.User.RoleNotDeleted);
    }
}