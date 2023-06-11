using Otus.Domain.Users;

namespace Otus.Service.Logic.Users;

public interface IUsersLogic
{
    Task<IEnumerable<User>> GetUsers();
    Task<User?> GetUserById(long userId);
    Task<long> Register(User user);
}