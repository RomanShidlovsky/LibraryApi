using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Errors;
using MediatR;

namespace Application.Features.UserFeatures.Commands.AddRole;

public class AddUserRoleCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<AddUserRoleCommand, Response>
{
    public async Task<Response> Handle(AddUserRoleCommand request, CancellationToken cancellationToken)
    {
        var succeeded = await unitOfWork.GetRepository<IUserRepository>()
            .AddRoleAsync(request.UserId, request.RoleId, cancellationToken);

        if (succeeded)
        {
            await unitOfWork.SaveAsync(cancellationToken);
        }

        return succeeded
            ? Response.Success()
            : Response.Failure(DomainErrors.User.RoleNotAdded);
    }
}