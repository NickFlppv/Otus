using Otus.Core.Models;
using Otus.Domain.UserCards;

namespace Otus.Service.Logic.UserCards;

public interface IUserCardsLogic
{
    Task<IEnumerable<UserCard>> GetUserCards(SearchFilters filters);
}