using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Otus.DataAccess;
using Otus.Domain.Users;
using Otus.Postgres.Dtos;
using Otus.Service.Logic.Users;

namespace Otus.Service.Logic.Auth;

public class AuthLogic : IAuthLogic
{
    private readonly IUsersDao<UserDto> _usersDao;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IMapper _mapper;

    public AuthLogic(IUsersDao<UserDto> usersDao, IPasswordHasher<User> passwordHasher, IMapper mapper)
    {
        _usersDao = usersDao;
        _passwordHasher = passwordHasher;
        _mapper = mapper;
    }

    public string CreateToken(ClaimsIdentity identity)
    {
        var now = DateTime.UtcNow;

        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            notBefore: now,
            claims: identity.Claims,
            expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                SecurityAlgorithms.HmacSha256));
        
        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    public async Task<ClaimsIdentity?> GetIdentity(int userId, string password)
    {
        var userDto = await _usersDao.GetUserById(userId);
        var user = _mapper.Map<UserDto?, User>(userDto);
        
        var verificationResult = _passwordHasher.VerifyHashedPassword(user, user.Password, password);
        
        if (user == null || PasswordVerificationResult.Failed == verificationResult)
            return null;

        var claims = new List<Claim>
        {
            new(ClaimsIdentity.DefaultNameClaimType, user.UserId.ToString())
        };
        var claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
        return claimsIdentity;
    }
}