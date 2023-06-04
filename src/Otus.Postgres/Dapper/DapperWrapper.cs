using System.Data;
using Dapper;
using Microsoft.Extensions.Logging;
using Npgsql;
using Otus.DataAccess.Abstractions;

namespace Otus.Postgres.Dapper;

public abstract class DapperWrapper
{
    private readonly IConnectionString _connectionString;
    private readonly ILogger _logger;

    protected DapperWrapper(IConnectionString connectionString, ILogger logger)
    {
        _connectionString = connectionString;
        _logger = logger;
    }

    protected async Task<T> QueryFirstOrDefaultAsync<T>(string storedProcedure, CancellationToken cancellationToken, object param)
    {
        await using var connection = new NpgsqlConnection(_connectionString.Value);

        try
        {
            await connection.OpenAsync(cancellationToken);

            var commandDefinition = new CommandDefinition(storedProcedure, param, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken);

            var result = await connection.QueryFirstOrDefaultAsync<T>(commandDefinition);
            
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
    
    protected async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(
        string sql, 
        Func<TFirst, TSecond, TReturn> map, 
        object args,
        string splitOn,
        CancellationToken cancellationToken)
    {
        await using var connection = new NpgsqlConnection(_connectionString.Value);

        try
        {
            await connection.OpenAsync(cancellationToken);
            
            return await connection.QueryAsync(sql, map, args, splitOn: splitOn);
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
    
    protected async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(
        string sql, 
        Func<TFirst, TSecond, TThird, TReturn> map, 
        object args,
        string splitOn,
        CancellationToken cancellationToken)
    {
        await using var connection = new NpgsqlConnection(_connectionString.Value);

        try
        {
            await connection.OpenAsync(cancellationToken);
            
            return await connection.QueryAsync(sql, map, args, splitOn: splitOn);
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
    
    
    protected async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(
        string sql, 
        Func<TFirst, TSecond, TThird, TFourth, TReturn> map, 
        object args,
        string splitOn,
        CancellationToken cancellationToken)
    {
        await using var connection = new NpgsqlConnection(_connectionString.Value);

        try
        {
            await connection.OpenAsync(cancellationToken);
            
            return await connection.QueryAsync(sql, map, args, splitOn: splitOn);
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
    
    protected async Task ExecuteAsync(string sql, object args, CancellationToken cancellationToken)
    {
        await using var connection = new NpgsqlConnection(_connectionString.Value);

        try
        {
            await connection.OpenAsync(cancellationToken);

            await connection.ExecuteAsync(sql, args);
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