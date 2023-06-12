using Otus.DataAccess;
using Otus.Postgres;
using Otus.Postgres.Connections;
using Otus.Postgres.Dtos;
using Otus.Service.Logic.Auth;
using Otus.Service.Logic.Users;

namespace Otus.Service.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static void AddLogic(this IServiceCollection services)
    {
        services.AddTransient<IUsersLogic, UsersLogic>();
        services.AddTransient<IAuthLogic, AuthLogic>();
    }

    public static void AddNpgsql(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IMainConnectionString>(new MainConnectionString(configuration.GetNpgsqlConnectionString(ConnectionStringNames.MainConnection)));
    }
    
    public static void AddDataAccess(this IServiceCollection services)
    {
        services.AddTransient<IUserCardsDao<UserCardDto>, UserCardsDao>();
        services.AddTransient<IUsersDao<UserDto>, UsersDao>();
    }
}