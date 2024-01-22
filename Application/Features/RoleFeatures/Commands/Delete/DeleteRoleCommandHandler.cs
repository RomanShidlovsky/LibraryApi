﻿using Application.DTOs.Genre;
using Application.DTOs.Role;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.RoleFeatures.Commands.Delete;

public class DeleteRoleCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : IDeleteCommandHandler<DeleteRoleCommand, RoleViewModel>
{
    public async Task<Response<RoleViewModel>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<IRoleRepository>();
        
        var role = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (role == null)
            return new NotFoundException(request.Id, typeof(Role));
        
        repository.Delete(role);
        await unitOfWork.SaveAsync(cancellationToken);

        return mapper.Map<RoleViewModel>(role);
    }
}
    