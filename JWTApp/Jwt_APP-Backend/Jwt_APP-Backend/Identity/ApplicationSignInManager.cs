using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Jwt_APP_Backend.Identity
{
  public class ApplicationSignInManager:SignInManager<ApplicationUser>
  {
    public ApplicationSignInManager(ApplicationUserManager applicationUserManager,
IHttpContextAccessor httpContextAccessor, IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory,
IOptions<IdentityOptions> options, ILogger<ApplicationSignInManager> logger,
IAuthenticationSchemeProvider authenticationSchemeProvider, IUserConfirmation<ApplicationUser> userConfirmation
) : base(applicationUserManager, httpContextAccessor, userClaimsPrincipalFactory, options, logger, authenticationSchemeProvider, userConfirmation)
    {

    }
  }
}
