using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Otus.Service.Logic.Auth;

public class AuthOptions
{
    public const string ISSUER = "OtusService";
    public const string AUDIENCE = "OtusServiceClient";
    const string KEY = "mysupersecret_secretkey!123";
    public const int LIFETIME = 999;

    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
    }
}