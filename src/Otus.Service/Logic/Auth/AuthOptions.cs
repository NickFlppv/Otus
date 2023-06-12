using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Otus.Service.Logic.Auth;

public class AuthOptions
{
    public const string ISSUER = "otus.service";
    public const string AUDIENCE = "otus.service.client";
    const string KEY = "mysupersecret_secretkey!123";
    public const int LIFETIME = 999;

    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
    }
}