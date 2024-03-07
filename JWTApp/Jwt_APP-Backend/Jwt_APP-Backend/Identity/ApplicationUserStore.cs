using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Jwt_APP_Backend.Identity
{
  public class ApplicationUserStore:UserStore<ApplicationUser>
  {
    public ApplicationUserStore(ApplicationDbContext context):base(context)
    {

    }
  }
}
