using Dapper;
using Microsoft.Extensions.Logging;
using Npgsql;
using Otus.DataAccess;
using Otus.Postgres.Connections;
using Otus.Postgres.Dapper;
using Otus.Postgres.Dtos;

namespace Otus.Postgres;

public class UsersDao : DapperWrapper, IUsersDao<UserDto>
{
    public UsersDao(IMainConnectionString connectionString, ILogger logger) : base(connectionString, logger)
    {
    }

    public async Task<UserDto?> GetUserById(long userId)
    {
        await using var con = new NpgsqlConnection(_connectionString.Value);

        var sql = "Select * from users where \"userId\" = @UserId";

        return await con.QueryFirstOrDefaultAsync<UserDto>(sql, new { UserId = userId });
    }

    public async Task<IEnumerable<UserDto>> GetUsers()
    {
        await using var con = new NpgsqlConnection(_connectionString.Value);
        
        var sql = "Select * from users";
        
        return await con.QueryAsync<UserDto>(sql);
    }

    public async Task<long> AddUser(UserDto user)
    {
        var sql = "Insert into users (email, password, \"registeredAt\", \"isTestAccount\", \"isBlocked\") " +
                  "Values(@Email, @Password, @RegisteredAt, @IsTestAccount, @IsBlocked) RETURNING \"userId\";";
        
        return await Mutate<long>(sql,
            new
            {
                user.Email,
                user.Password,
                user.RegisteredAt,
                user.IsTestAccount,
                user.IsBlocked
            });
    }
}