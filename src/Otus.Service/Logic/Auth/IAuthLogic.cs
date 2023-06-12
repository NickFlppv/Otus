using System.Security.Claims;

namespace Otus.Service.Logic.Auth;

public interface IAuthLogic
{
    string CreateToken(ClaimsIdentity identity);
    Task<ClaimsIdentity?> GetIdentity(int userId, string password);
}