using Jwt_APP_Backend.Modals;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Jwt_APP_Backend.Identity
{
  public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {

    }
    public DbSet<ApplicationRole> ApplicationRoles { get; set; }
    public DbSet<Employee> Employees { get; set; }
  }
}
