using Jwt_APP_Backend.Identity;
using Jwt_APP_Backend.Modals;
using Jwt_APP_Backend.ServicesContract;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Jwt_APP_Backend.Services
{
  public class UserServices : IUserService
  {
    private readonly ApplicationUserManager _applicationUserManager;
    private readonly ApplicationSignInManager _applicationSignInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly AppSettings _appSettings;
    public UserServices(ApplicationUserManager applicationUserManager,
      ApplicationSignInManager applicationSignInManager,
      UserManager<ApplicationUser> userManager,
      IOptions<AppSettings> appSettings)
    {
      _applicationUserManager = applicationUserManager;
      _applicationSignInManager = applicationSignInManager;
      _userManager = userManager;
      _appSettings = appSettings.Value;
    }

    public async Task<ApplicationUser> Authentication(LoginViewModel loginViewModel)
    {
      var result = await _applicationSignInManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, false, false);
      if (result.Succeeded)
      {
        var applicationUser = await _applicationUserManager.FindByNameAsync(loginViewModel.Username);
        applicationUser.PasswordHash = "";
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescritor = new SecurityTokenDescriptor()
        {
          Subject = new ClaimsIdentity(new Claim[]
          {
            new Claim(ClaimTypes.Name, applicationUser.Id),
            new Claim(ClaimTypes.Email, applicationUser.Email)
          }
          ),
          Expires = DateTime.UtcNow.AddHours(30),
          SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescritor);
        applicationUser.Token = tokenHandler.WriteToken(token);
        return applicationUser;
      }
      else
      {
        return null;
      }
    }
  }
}
