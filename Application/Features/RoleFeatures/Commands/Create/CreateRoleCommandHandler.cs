using Application.DTOs.Role;
using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using Domain.Errors;

namespace Application.Features.RoleFeatures.Commands.Create;

public class CreateRoleCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : ICreateCommandHandler<CreateRoleCommand, RoleViewModel>
{
    public async Task<Response<RoleViewModel>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<IRoleRepository>();
        
        var role = (await repository.GetAsync(g => g.Name == request.Name, cancellationToken)).SingleOrDefault();

        if (role != null)
            return Response.Failure<RoleViewModel>(DomainErrors.Role.NameConflict);

        var newRole = mapper.Map<Role>(request);
        repository.Create(newRole);
        await unitOfWork.SaveAsync(cancellationToken);

        return mapper.Map<RoleViewModel>(newRole);
    }
}