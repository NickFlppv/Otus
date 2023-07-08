using Dapper;
using Microsoft.Extensions.Logging;
using Npgsql;
using Otus.Core.Models;
using Otus.DataAccess;
using Otus.Postgres.Connections;
using Otus.Postgres.Dapper;
using Otus.Postgres.Dtos;

namespace Otus.Postgres;

public class UserCardsDao : DapperWrapper, IUserCardsDao<UserCardDto>
{
    public UserCardsDao(IMainConnectionString connectionString, ILogger<DapperWrapper> logger) : base(connectionString, logger)
    {
    }

    public async Task<IEnumerable<UserCardDto>> GetUserCards(SearchFilters filters)
    {
        await using var con = new NpgsqlConnection(_connectionString.Value);

        filters.Limit ??= 100;

        var sql = "Select * from usercards " +
                  "Left join genders on usercards.\"genderId\" = genders.\"genderId\" " +
                  "Where usercards.\"name\" ~~* ('%' || coalesce(@SearchTerm, '') || '%') or " +
                  "usercards.\"surname\" ~~* ('%' || coalesce(@SearchTerm, '') || '%') " +
                  "Order by usercards.\"userCardId\" " +
                  "Limit @Limit";

        return await con.QueryAsync<UserCardDto, GenderDto, UserCardDto>(sql, (userCard, gender) =>
            {
                userCard.Gender = gender;
                return userCard;
            }, 
            new { SearchTerm = filters.SearchTerm, Limit = filters.Limit },
            splitOn: "GenderId"
        );
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
                userCard.Gender?.GenderId,
                userCard.City,
                userCard.Biography
            });
    }
}