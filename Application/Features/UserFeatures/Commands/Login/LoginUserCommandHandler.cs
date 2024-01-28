using System.IdentityModel.Tokens.Jwt;
using Application.Auth;
using Application.Interfaces.Authentication;
using Application.Interfaces.Commands;
using Application.Wrappers;
using Domain.Entities;
using Domain.Errors;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.UserFeatures.Commands.Login;

public class LoginUserCommandHandler(
    JwtOptions jwtOptions,
    IJwtTokenProvider tokenProvider,
    UserManager<User> userManager) 
    : IUpdateCommandHandler<LoginUserCommand, TokenModel>
{
    public async Task<Response<TokenModel>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByNameAsync(request.UserName);
        if (user == null)
            return Response.Failure<TokenModel>(DomainErrors.User.InvalidCredentials);

        var isPasswordValid = await userManager.CheckPasswordAsync(user, request.Password);
        if (!isPasswordValid)
            return Response.Failure<TokenModel>(DomainErrors.User.InvalidCredentials);

        var userRoles = await userManager.GetRolesAsync(user);

        var token = tokenProvider.GetJwtToken(user, userRoles);
        var refreshToken = tokenProvider.GetRefreshToken();

        user.RefreshToken = refreshToken;
        var l = refreshToken.Length;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(jwtOptions.RefreshTokenValidityInDays);
        await userManager.UpdateAsync(user);

        return new TokenModel(
            new JwtSecurityTokenHandler().WriteToken(token),
            token.ValidTo,
            refreshToken);
    }
}