using System.Data;
using Dapper;
using Microsoft.Extensions.Logging;
using Npgsql;
using Otus.DataAccess.Abstractions;

namespace Otus.Postgres.Dapper;

public abstract class DapperWrapper
{
    protected readonly IConnectionString _connectionString;
    private readonly ILogger _logger;

    protected DapperWrapper(IConnectionString connectionString, ILogger logger)
    {
        _connectionString = connectionString;
        _logger = logger;
    }

    protected async Task<TReturn> CallStoredProcedure<TReturn>(string storedProcedure, CancellationToken cancellationToken, object param)
    {
        await using var connection = new NpgsqlConnection(_connectionString.Value);

        try
        {
            await connection.OpenAsync(cancellationToken);

            var commandDefinition = new CommandDefinition(storedProcedure, param, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken);

            var result = await connection.QueryFirstOrDefaultAsync<TReturn>(commandDefinition);
            
            return result;
        }
        catch (NpgsqlException e)
        {
            _logger.LogError(e, "SqlState: {SqlState}. ErrorCode: {ErrorCode}. Message: {Message}", e.SqlState,
                e.ErrorCode, e.Message);

            throw;
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);

            throw;
        }
    }

    protected async Task<TReturn> Mutate<TReturn>(string sql, object args, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
    {
        await using var connection = new NpgsqlConnection(_connectionString.Value);

        try
        {
            await connection.OpenAsync(cancellationToken);

            return await connection.QueryFirstOrDefaultAsync<TReturn>(sql, args, transaction);
        }
        catch (NpgsqlException e)
        {
            _logger.LogError(e, "SqlState: {SqlState}. ErrorCode: {ErrorCode}. Message: {Message}", e.SqlState,
                e.ErrorCode, e.Message);

            throw;
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);

            throw;
        }
    }
}