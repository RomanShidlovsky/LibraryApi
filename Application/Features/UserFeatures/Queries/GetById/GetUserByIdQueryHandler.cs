using Application.DTOs.User;
using Application.Exceptions;
using Application.Interfaces.Queries;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.UserFeatures.Queries.GetById;

public class GetUserByIdQueryHandler(
    IUserRepository repository,
    IMapper mapper)
    : ISingleQueryHandler<GetUserByIdQuery, UserViewModel>
{
    public async Task<Response<UserViewModel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (user == null)
            return new NotFoundException(request.Id, typeof(User));

        return mapper.Map<UserViewModel>(user);
    }
}