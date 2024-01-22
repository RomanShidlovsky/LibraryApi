using Application.DTOs.Genre;
using Application.DTOs.Role;
using Application.Exceptions;
using Application.Interfaces.Queries;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.RoleFeatures.Queries.GetById;

public class GetRoleByIdQueryHandler(
    IRoleRepository repository,
    IMapper mapper)
    : ISingleQueryHandler<GetRoleByIdQuery, RoleViewModel>
{
    public async Task<Response<RoleViewModel>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var role =  await repository.GetByIdAsync(request.Id, cancellationToken);

        if (role is null)
            return new NotFoundException(request.Id, typeof(Role));

        return mapper.Map<RoleViewModel>(role);
    }
}