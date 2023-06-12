using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Otus.DataAccess;
using Otus.Domain.UserCards;
using Otus.Domain.Users;
using Otus.Postgres.Dtos;

namespace Otus.Service.Logic.Users;

public class UsersLogic : IUsersLogic
{
    private readonly IUsersDao<UserDto> _usersDao;
    private readonly IUserCardsDao<UserCardDto> _userCardsDao;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IMapper _mapper;

    public UsersLogic(
        IUsersDao<UserDto> usersDao, 
        IUserCardsDao<UserCardDto> userCardsDao,
        IPasswordHasher<User> passwordHasher,
        IMapper mapper
        )
    {
        _usersDao = usersDao;
        _userCardsDao = userCardsDao;
        _passwordHasher = passwordHasher;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<User>> GetUsers()
    {
        var userDtos = await _usersDao.GetUsers();

        return _mapper.Map<IEnumerable<UserDto>, IEnumerable<User>>(userDtos);
    }

    public async Task<User?> GetUserById(long userId)
    {
        var user = await _usersDao.GetUserById(userId);

        return _mapper.Map<UserDto?, User?>(user);
    }

    public async Task<long> Register(User user)
    {
        var hashedPassword = _passwordHasher.HashPassword(user, user.Password);
        user.Password = hashedPassword;
        
        var userDto = _mapper.Map<User, UserDto>(user);

        var userId = await _usersDao.AddUser(userDto);

        if (user.UserCard is not null)
        {
            var userCard = _mapper.Map<UserCard?, UserCardDto>(user.UserCard);
            userCard.UserId = userId;
            await _userCardsDao.AddUserCard(userCard);
        }
        
        return userId;
    }
}