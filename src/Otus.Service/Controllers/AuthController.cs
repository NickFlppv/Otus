using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Otus.Service.Logic.Auth;

namespace Otus.Service.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthLogic _authLogic;

    public AuthController(IAuthLogic authLogic)
    {
        _authLogic = authLogic;
    }
    
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Login(int id, string password)
    {
        var identity = await _authLogic.GetIdentity(id, password);
        if (identity == null)
            return BadRequest(new { errorText = "Invalid username or password." });

        return new JsonResult(new
        {
            access_token = _authLogic.CreateToken(identity),
            username = identity.Name
        });
    }
}