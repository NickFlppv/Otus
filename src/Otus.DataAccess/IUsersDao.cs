using Otus.DataAccess.Abstractions;

namespace Otus.DataAccess;

public interface IUsersDao<T> where T: class, IDataAccessDto
{
    Task<IEnumerable<T>> GetUsers();
    Task<T?> GetUserById(long userId);
    Task<long> AddUser(T user);
}