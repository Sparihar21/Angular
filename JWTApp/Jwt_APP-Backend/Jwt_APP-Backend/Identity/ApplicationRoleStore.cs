using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Jwt_APP_Backend.Identity
{
  public class ApplicationRoleStore:RoleStore<ApplicationRole>
  {
    public ApplicationRoleStore(ApplicationDbContext context):base(context) 
    {

    }
  }
}
