using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Application.Interfaces.Authentication;
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Application.Auth;

public class JwtTokenProvider(JwtOptions jwtOptions) : IJwtTokenProvider
{
    public JwtSecurityToken GetJwtToken(User user, IEnumerable<string> roles)
    {
        var claims = new List<Claim>()
        {
            new("Id", user.Id.ToString()),
            new("UserName", user.UserName),
        };
        
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            jwtOptions.Issuer,
            null,
            claims,
            null,
            DateTime.UtcNow.AddMinutes(jwtOptions.TokenValidityInMinutes),
            signingCredentials);

        return token;
    }

    public string GetRefreshToken()
    {
        var randomNumber = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }
}