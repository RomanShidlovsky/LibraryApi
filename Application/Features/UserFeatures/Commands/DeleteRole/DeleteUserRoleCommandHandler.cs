using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;

namespace Application.Features.UserFeatures.Commands.DeleteRole;

public class DeleteUserRoleCommandHandler(IUnitOfWork unitOfWork)
    : IUpdateCommandHandler<DeleteUserRoleCommand, bool>
{
    public async Task<Response<bool>> Handle(DeleteUserRoleCommand request, CancellationToken cancellationToken)
    {
        var result = await unitOfWork.GetRepository<IUserRepository>()
            .DeleteRoleAsync(request.UserId, request.RoleId, cancellationToken);

        await unitOfWork.SaveAsync(cancellationToken);

        return result;
    }
}