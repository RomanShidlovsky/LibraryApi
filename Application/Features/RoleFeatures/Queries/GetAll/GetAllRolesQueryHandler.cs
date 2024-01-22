using Application.DTOs.Role;
using Application.Interfaces.Queries;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;

namespace Application.Features.RoleFeatures.Queries.GetAll;

public class GetAllRolesQueryHandler(
    IRoleRepository repository,
    IMapper mapper) 
    : IQueryHandler<GetAllRolesQuery, IEnumerable<RoleViewModel>>
{
    public async Task<Response<IEnumerable<RoleViewModel>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {
        var rolesList = await repository.GetAllAsync(cancellationToken);

        return mapper.Map<List<RoleViewModel>>(rolesList);
    }
}