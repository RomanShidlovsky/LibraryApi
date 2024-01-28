using System.IdentityModel.Tokens.Jwt;
using Domain.Entities;

namespace Application.Interfaces.Authentication;

public interface IJwtTokenProvider
{
    JwtSecurityToken GetJwtToken(User user, IEnumerable<string> roles);
    string GetRefreshToken();
}