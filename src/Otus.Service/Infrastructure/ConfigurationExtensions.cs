using Npgsql;
using Otus.Postgres.Connections;

namespace Otus.Service.Infrastructure;

public static class ConfigurationExtensions
{
    public static string GetNpgsqlConnectionString(this IConfiguration configuration, string name)
    {
        var options = configuration?.GetSection(name).Get<NpgsqlConnectionOptions>();

        var builder = new NpgsqlConnectionStringBuilder(options.ConnectionString)
        {
            Username = options.Username,
            Password = options.Password
        };
        
        return builder.ToString();
    }
}