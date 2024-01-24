using Domain.Entities;

namespace Application.Interfaces.Authentication;

public interface IJwtTokenProvider
{
    string GetJwtToken(User user);
}