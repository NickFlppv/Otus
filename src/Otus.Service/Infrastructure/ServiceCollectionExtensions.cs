using Microsoft.AspNetCore.Identity;
using Otus.DataAccess;
using Otus.Domain.Users;
using Otus.Postgres;
using Otus.Postgres.Connections;
using Otus.Postgres.Dtos;
using Otus.Service.Logic.Auth;
using Otus.Service.Logic.UserCards;
using Otus.Service.Logic.Users;

namespace Otus.Service.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static void AddLogic(this IServiceCollection services)
    {
        services.AddTransient<IUsersLogic, UsersLogic>();
        services.AddTransient<IUserCardsLogic, UserCardsLogic>();
        services.AddTransient<IAuthLogic, AuthLogic>();
    }

    public static void AddNpgsql(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetNpgsqlConnectionString(ConnectionStringNames.MainConnection);
        services.AddSingleton<IMainConnectionString>(new MainConnectionString(connectionString));
    }

    public static void AddPasswordHasher(this IServiceCollection services)
    {
        services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();
    }
    
    public static void AddDataAccess(this IServiceCollection services)
    {
        services.AddTransient<IUserCardsDao<UserCardDto>, UserCardsDao>();
        services.AddTransient<IUsersDao<UserDto>, UsersDao>();
    }
}