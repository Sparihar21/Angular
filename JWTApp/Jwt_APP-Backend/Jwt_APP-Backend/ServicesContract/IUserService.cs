using Jwt_APP_Backend.Identity;
using Jwt_APP_Backend.Modals;

namespace Jwt_APP_Backend.ServicesContract
{
  public interface IUserService
  {
    Task<ApplicationUser> Authentication(LoginViewModel loginViewModel);
  }
}
