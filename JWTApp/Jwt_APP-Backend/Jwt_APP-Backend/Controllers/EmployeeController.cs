using Jwt_APP_Backend.Identity;
using Jwt_APP_Backend.Modals;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Jwt_APP_Backend.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Jwt_APP_Backend.Controllers
{
  [Route("api/employee")]
  [ApiController]
  [Authorize]
  public class EmployeeController : Controller
  {
    private readonly ApplicationDbContext _context;
    public EmployeeController(ApplicationDbContext context)
    {
      _context = context;
    }
    [HttpGet]
    public IActionResult GetAllEmployee()
    {
      return Ok(_context.Employees.ToList());
    }
    [HttpPost]
    public IActionResult AddEmployee([FromBody] Employee employee)
    {
      if (employee == null) return BadRequest();
      if (!ModelState.IsValid) return NotFound();
      _context.Employees.Add(employee);
      _context.SaveChanges();
      return Ok();
    }
    [HttpPut]
    public IActionResult UpdateEmployee([FromBody] Employee employee)
    {
      if (employee == null) return BadRequest();
      if (!ModelState.IsValid) return NotFound();
      _context.Employees.Update(employee);
      _context.SaveChanges();
      return Ok();
    }
    [HttpDelete("{id:int}")]
    public IActionResult DeleteEmployee(int id)
    {
      var employeeInDb = _context.Employees.Find(id);
      if (employeeInDb == null) return BadRequest();
      _context.Employees.Remove(employeeInDb);
      _context.SaveChanges();
      return Ok();
    }
  }
}
