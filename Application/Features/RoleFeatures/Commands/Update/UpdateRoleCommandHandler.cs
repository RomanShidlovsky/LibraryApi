using Application.DTOs.Genre;
using Application.DTOs.Role;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.RoleFeatures.Commands.Update;

public class UpdateRoleCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : IUpdateCommandHandler<UpdateRoleCommand, RoleViewModel>
{
    public async Task<Response<RoleViewModel>> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<IRoleRepository>();
        
        var role = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (role == null)
            return new NotFoundException(request.Id, typeof(Role));

        var updatedRole = mapper.Map<Role>(request);
        
        repository.Update(updatedRole);
        await unitOfWork.SaveAsync(cancellationToken);

        return mapper.Map<RoleViewModel>(updatedRole);
    }
}