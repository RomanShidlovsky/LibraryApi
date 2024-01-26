using Application.Auth;
using Application.Interfaces;
using Application.Interfaces.Authentication;
using Application.Interfaces.Commands;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Errors;

namespace Application.Features.UserFeatures.Commands.Login;

public class LoginUserCommandHandler(
    IUnitOfWork unitOfWork,
    IJwtTokenProvider jwtTokenProvider)
    : IUpdateCommandHandler<LoginUserCommand, string>
{
    public async Task<Response<string>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.GetRepository<IUserRepository>()
            .GetByUsernameAsync(request.Username, cancellationToken);

        if (user == null)
            return Response.Failure<string>(DomainErrors.User.InvalidCredentials);

        var passwordHash = HashHelper.GetPasswordHash(request.Password);
        if (passwordHash != user.Password)
            return Response.Failure<string>(DomainErrors.User.InvalidCredentials);

        var token = jwtTokenProvider.GetJwtToken(user);

        return token;
    }
}