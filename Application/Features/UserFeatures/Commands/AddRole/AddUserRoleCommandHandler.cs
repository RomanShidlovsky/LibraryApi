using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;

namespace Application.Features.UserFeatures.Commands.AddRole;

public class AddUserRoleCommandHandler(IUnitOfWork unitOfWork)
    : IUpdateCommandHandler<AddUserRoleCommand, bool>
{
    public async Task<Response<bool>> Handle(AddUserRoleCommand request, CancellationToken cancellationToken)
    {
        var result = await unitOfWork.GetRepository<IUserRepository>()
            .AddRoleAsync(request.UserId, request.RoleId, cancellationToken);

        await unitOfWork.SaveAsync(cancellationToken);

        return result;
    }
}