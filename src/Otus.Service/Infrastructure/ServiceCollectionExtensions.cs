using Otus.DataAccess;
using Otus.Postgres;
using Otus.Postgres.Dtos;
using Otus.Service.Logic.UserCards;

namespace Otus.Service.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static void AddLogic(this IServiceCollection services)
    {
        services.AddTransient<IUserCardsLogic, UserCardsLogic>();
    }

    public static void AddDataAccess(this IServiceCollection services)
    {
        services.AddTransient<IUserCardsDao<UserCardDto>, UserCardsDao>();
    }
}