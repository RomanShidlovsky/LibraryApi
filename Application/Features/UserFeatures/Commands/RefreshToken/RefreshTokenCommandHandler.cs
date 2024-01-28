using System.IdentityModel.Tokens.Jwt;
using Application.Auth;
using Application.Interfaces.Authentication;
using Application.Interfaces.Commands;
using Application.Wrappers;
using Domain.Entities;
using Domain.Errors;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Application.Features.UserFeatures.Commands.RefreshToken;

public class RefreshTokenCommandHandler(
    JwtOptions jwtOptions,
    IJwtTokenProvider tokenProvider,
    UserManager<User> userManager)
    : IUpdateCommandHandler<RefreshTokenCommand, TokenModel>
{
    public async Task<Response<TokenModel>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var validationParameters = jwtOptions.ValidationParameters;
        validationParameters.ValidateLifetime = false;

        var tokenHandler = new JwtSecurityTokenHandler();
        var result = await tokenHandler.ValidateTokenAsync(request.AccessToken, validationParameters);
        if (!result.IsValid)
            return Response.Failure<TokenModel>(DomainErrors.User.InvalidAccessOrRefreshTokenToken);

        result.Claims.TryGetValue("UserName", out var userNameObj);
        if (userNameObj == null)
            return Response.Failure<TokenModel>(DomainErrors.User.InvalidAccessOrRefreshTokenToken);

        var userName = (string)userNameObj;

        var user = await userManager.FindByNameAsync(userName);
        if (user == null || user.RefreshToken != request.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            return Response.Failure<TokenModel>(DomainErrors.User.InvalidAccessOrRefreshTokenToken);

        var userRoles = await userManager.GetRolesAsync(user);

        var accessToken = tokenProvider.GetJwtToken(user, userRoles);
        var refreshToken = tokenProvider.GetRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(jwtOptions.RefreshTokenValidityInDays);
        
        return new TokenModel(
            new JwtSecurityTokenHandler().WriteToken(accessToken), 
            accessToken.ValidTo, 
            refreshToken);
    }
}