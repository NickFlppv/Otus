using Otus.DataAccess.Abstractions;

namespace Otus.DataAccess;

public interface IUserCardsDao<T> where T: class, IDataAccessDto
{
    Task<long> AddUserCard(T userCard);
}