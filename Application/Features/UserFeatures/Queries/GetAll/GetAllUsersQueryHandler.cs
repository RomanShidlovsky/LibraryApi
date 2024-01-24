using Application.DTOs.User;
using Application.Interfaces.Queries;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;

namespace Application.Features.UserFeatures.Queries.GetAll;

public class GetAllUsersQueryHandler(
    IUserRepository repository,
    IMapper mapper)
    : IQueryHandler<GetAllUsersQuery, IEnumerable<UserViewModel>>
{
    public async Task<Response<IEnumerable<UserViewModel>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var usersList = await repository.GetAllAsync(cancellationToken);

        return mapper.Map<List<UserViewModel>>(usersList);
    }
}