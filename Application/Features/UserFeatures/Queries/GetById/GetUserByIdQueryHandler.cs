using Application.DTOs.User;
using Application.Interfaces.Queries;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Errors;

namespace Application.Features.UserFeatures.Queries.GetById;

public class GetUserByIdQueryHandler(IUserRepository repository, IMapper mapper)
    : ISingleQueryHandler<GetUserByIdQuery, UserViewModel>
{
    public async Task<Response<UserViewModel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await repository.GetByIdAsync(request.Id, cancellationToken);

        return user == null
            ? Response.Failure<UserViewModel>(DomainErrors.User.UserNotFoundById)
            : mapper.Map<UserViewModel>(user);
    }
}