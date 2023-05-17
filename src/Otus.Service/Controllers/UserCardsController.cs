using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Otus.Contracts;
using Otus.Core.Models;
using Otus.Domain.UserCards;
using Otus.Service.Logic.UserCards;

namespace Otus.Service.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserCardsController : ControllerBase
{
    private readonly IUserCardsLogic _userCardsLogic;
    private readonly IMapper _mapper;

    public UserCardsController(IUserCardsLogic userCardsLogic, IMapper mapper)
    {
        _userCardsLogic = userCardsLogic;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<UserCardResponse>> GetUserCards([FromQuery]PaginationInfo pagination)
    {
        var userCards = await _userCardsLogic.GetUserCards(pagination);

        var dtos = _mapper.Map<IEnumerable<UserCard>, IEnumerable<UserCardResponse>>(userCards);

        return dtos;
    }
}