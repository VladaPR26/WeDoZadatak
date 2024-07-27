using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WorkoutTracker.Buissiness.Contracts;
using WorkoutTracker.Buissiness.Services;
using WorkoutTracker.Buissiness.Services.Users.Requests;
using WorkoutTracker.DAL.Entities.Users;

namespace WorkoutTracker.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterRequest user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _userService.Register(user);
        return Ok();
    }
    [HttpPost("login")]
    public async Task<ActionResult> Login(LoginRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var response=await _userService.Login(request);
        return Ok(response);
    }


}
