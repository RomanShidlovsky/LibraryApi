using System.Security.Cryptography;
using System.Text;

namespace Application.Auth;

public static class HashHelper
{
    public static string GetPasswordHash(string password)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        
        var builder = new StringBuilder();
        foreach (var b in bytes)
        {
            builder.Append(b.ToString("x2"));
        }
        
        return builder.ToString();
    }
}