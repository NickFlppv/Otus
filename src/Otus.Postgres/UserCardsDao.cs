using Microsoft.Extensions.Logging;
using Otus.Core.Models;
using Otus.DataAccess;
using Otus.Postgres.Connections;
using Otus.Postgres.Dapper;
using Otus.Postgres.Dtos;

namespace Otus.Postgres;

public class UserCardsDao : DapperWrapper, IUserCardsDao<UserCardDto>
{
    public UserCardsDao(IMainConnectionString connectionString, ILogger logger) : base(connectionString, logger)
    {
    }
    
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