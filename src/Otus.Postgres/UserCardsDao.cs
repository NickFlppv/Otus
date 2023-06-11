using Microsoft.Extensions.Logging;
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

    public async Task<long> AddUserCard(UserCardDto userCard)
    {
        var sql = "Insert into usercards (\"userId\", name, surname, birthday, \"genderId\", city, biography) " +
                  "Values(@UserId, @Name, @Surname, @Birthday, @GenderId, @City, @Biography) RETURNING \"userCardId\";";

        return await Mutate<long>(sql,
            new
            {
                userCard.UserId,
                userCard.Name,
                userCard.Surname,
                userCard.Birthday,
                userCard.GenderId,
                userCard.City,
                userCard.Biography
            });
    }
}