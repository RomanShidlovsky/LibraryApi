using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Interfaces.Authentication;
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Application.Auth;

public class JwtTokenProvider(JwtOptions jwtOptions) : IJwtTokenProvider
{
    public string GetJwtToken(User user)
    {
        var claims = new List<Claim>()
        {
            new("Id", user.Id.ToString()),
            new("Username", user.Username),
            new(ClaimTypes.Email, user.Email)
        };
        
        claims.AddRange(user.Roles.Select(role => new Claim(ClaimTypes.Role, role.Name)));

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            jwtOptions.Issuer,
            null,
            claims,
            null,
            DateTime.UtcNow.AddHours(1),
            signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}