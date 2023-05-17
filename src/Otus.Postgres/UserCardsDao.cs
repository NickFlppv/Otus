using Otus.Core.Models;
using Otus.DataAccess;
using Otus.Postgres.Dtos;

namespace Otus.Postgres;

public class UserCardsDao : IUserCardsDao<UserCardDto>
{
    public async Task<IEnumerable<UserCardDto>> GetUserCards(PaginationInfo pagination)
    {
        return new[]
        {
            new UserCardDto
            {
                Name = "Nikolay",
                Surname = "Ivanov"
            }
        };
    }
}