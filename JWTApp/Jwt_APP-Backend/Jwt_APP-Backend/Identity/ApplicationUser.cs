using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jwt_APP_Backend.Identity
{
  public class ApplicationUser:IdentityUser
  {
    [NotMapped]
    public string Token { get; set; }
    [NotMapped]
    public string Role { get; set; }
  }
}
