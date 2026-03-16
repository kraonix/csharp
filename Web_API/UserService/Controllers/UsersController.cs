using Microsoft.AspNetCore.Mvc;
using UserServiceAPI.Models;
using UserServiceAPI.Services;

namespace UserServiceAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<User>> Get()
    {
        var users = _userService.GetUsers();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public ActionResult<User> Get(int id)
    {
        var user = _userService.GetUser(id);
        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpPost]
    public ActionResult Post([FromBody] User user)
    {
        _userService.CreateUser(user);
        return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] User user)
    {
        if (id != user.Id)
            return BadRequest();

        var existingUser = _userService.GetUser(id);
        if (existingUser == null)
            return NotFound();

        _userService.UpdateUser(user);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var existingUser = _userService.GetUser(id);
        if (existingUser == null)
            return NotFound();

        _userService.DeleteUser(id);
        return NoContent();
    }
}
