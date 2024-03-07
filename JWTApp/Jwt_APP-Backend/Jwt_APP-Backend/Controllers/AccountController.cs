using Jwt_APP_Backend.Identity;
using Jwt_APP_Backend.Modals;
using Jwt_APP_Backend.ServicesContract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Jwt_APP_Backend.Controllers
{
  [Route("api/account")]
  [ApiController]
  public class AccountController : Controller
  {
    private readonly IUserService _userService;
    public AccountController(IUserService userService)
    {
      _userService = userService;
    }
    [HttpPost("Authenticate")]
    public async Task<IActionResult> Authenticate([FromBody]LoginViewModel loginViewModel)
    {
      var user = await _userService.Authentication(loginViewModel);
      if (user == null) return BadRequest("id/pw not matched");
      return Ok(user);
    }
  }
}
