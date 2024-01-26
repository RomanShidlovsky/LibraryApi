using Application.DTOs.Role;
using Application.Interfaces.Queries;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Errors;

namespace Application.Features.RoleFeatures.Queries.GetById;

public class GetRoleByIdQueryHandler(
    IRoleRepository repository,
    IMapper mapper)
    : ISingleQueryHandler<GetRoleByIdQuery, RoleViewModel>
{
    public async Task<Response<RoleViewModel>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var role =  await repository.GetByIdAsync(request.Id, cancellationToken);

        return role == null
            ? Response.Failure<RoleViewModel>(DomainErrors.Role.RoleNotFoundById) 
            : mapper.Map<RoleViewModel>(role);
    }
}