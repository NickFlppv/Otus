using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Otus.Contracts;
using Otus.Core.Models;
using Otus.Domain.UserCards;
using Otus.Service.Logic.UserCards;

namespace Otus.Service.Controllers;

[Authorize]
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
    public async Task<IActionResult> GetUserCards([FromQuery] SearchFilters filters)
    {
        var userCards = await _userCardsLogic.GetUserCards(filters);

        var result = _mapper.Map<IEnumerable<UserCard>, IEnumerable<UserCardResponse>>(userCards);

        return Ok(result);
    }
}