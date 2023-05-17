using AutoMapper;
using Otus.Core.Models;
using Otus.DataAccess;
using Otus.Domain.UserCards;
using Otus.Postgres.Dtos;

namespace Otus.Service.Logic.UserCards;

public class UserCardsLogic : IUserCardsLogic
{
    private readonly IUserCardsDao<UserCardDto> _userCardsDao;
    private readonly IMapper _mapper;

    public UserCardsLogic(IUserCardsDao<UserCardDto> userCardsDao, IMapper mapper)
    {
        _userCardsDao = userCardsDao;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<UserCard>> GetUserCards(PaginationInfo pagination)
    {
        var userCardDtos = await _userCardsDao.GetUserCards(pagination);

        var userCards = _mapper.Map<IEnumerable<UserCardDto>, IEnumerable<UserCard>>(userCardDtos);

        return userCards;
    }
}