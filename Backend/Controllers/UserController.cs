

using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    //private readonly IUserService _service;

    public UserController(ILogger<UserController> logger/*, IUserService service*/)
    {
        _logger = logger;
        //_service = service;
    }

    [HttpGet("{id:guid}")]
    public ActionResult<User> GetSpecificUser(Guid id)
    {
        return Ok();
    }

    [HttpPost]
    public ActionResult<User> CreateUserAccount() // takes dto
    {
        return Ok();
    }

    [HttpPut("{id:guid}")]
    public ActionResult<User> EditUserSettings(Guid id) //also takes dto
    {
        return Ok();
    }

    [HttpPut("reset/{id:guid}")]
    public ActionResult<User> ResetUserPassword(Guid id) // also takes dto
    {
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public ActionResult DeleteUserAccount(Guid id)
    {
        return Ok();
    }


}