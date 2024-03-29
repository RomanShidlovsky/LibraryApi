﻿using Microsoft.IdentityModel.Tokens;

namespace Application.Auth;

public class JwtOptions
{
    public string Issuer { get; set; }
    public string Key { get; set; }
    public int TokenValidityInMinutes { get; set; }
    public int RefreshTokenValidityInDays { get; set; }
    public TokenValidationParameters ValidationParameters { get; set; }
}