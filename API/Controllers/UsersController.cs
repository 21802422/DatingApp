using API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace API.Controllers;

[Authorize]
[ApiController]
[Route("API/[controller]")] //api for users
public class UsersController : ControllerBase
{
  private readonly DataContext _context; // allows to e accessable to the rest of the class
  public UsersController(DataContext context)
  {
    _context = context;
  }

  
  [AllowAnonymous]
  [HttpGet] //retrieve a list if the all appUser object from DB and return Http Response
  public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
  {
    var users = await _context.User.ToListAsync();
    return users;
  }

  [HttpGet("{id}")] //retrieving a single appUsers object 4 DB on it PK and return it as HTTP
  public async Task<ActionResult<AppUser>> GetUser(int id)
  {
    return await _context.User.FindAsync(id);

  }


}
