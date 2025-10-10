using Backend.Dtos;
using Backend.Models;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _service;

    private readonly string REFRESH_TOKEN = "refreshToken";

    public UserController(ILogger<UserController> logger, IUserService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpPost("auth/register")]
    public async Task<ActionResult> RegisterUser([FromBody] AuthenticationDto register)
    {
        try
        {
            await _service.RegisterUser(register);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost("auth/login")]
    public async Task<ActionResult<AccessTokenDto>> LoginUser([FromBody] AuthenticationDto login)
    {
        try
        {
            var (refreshToken, accessToken) = await _service.LoginUser(login);

            SetRefreshTokenCookie(refreshToken);

            return Ok(accessToken);
        }
        catch (Exception e)
        {
            return Unauthorized("Incorrect credentials");
        }
    }

    [HttpPost("logout")]
    public async Task<ActionResult> LogoutUser()
    {
        try
        {
            var refreshTokenCookie = GetRefreshTokenCookie();
            await _service.LogoutUser(refreshTokenCookie);

            DeleteRefreshTokenCookie();

            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost("auth/refresh")]
    public async Task<ActionResult<AccessTokenDto>> RefreshTokens()
    {
        try
        {
            var oldRefreshTokenCookie = GetRefreshTokenCookie();
            var (refreshToken, accessToken) = await _service.RefreshTokens(oldRefreshTokenCookie);

            SetRefreshTokenCookie(refreshToken);

            return Ok(accessToken);
        }
        catch (Exception e)
        {
            return Unauthorized("Missing refresh token");
        }
    }

    // [HttpPut("{id:guid}")]
    // public ActionResult<User> EditUserSettings(Guid id) //also takes dto
    // {
    //     return Ok();
    // }

    // [HttpPut("reset/{id:guid}")]
    // public ActionResult<User> ResetUserPassword(Guid id) // also takes dto
    // {
    //     return Ok();
    // }

    // [HttpDelete("{id:guid}")]
    // public ActionResult DeleteUserAccount(Guid id)
    // {
    //     return Ok();
    // }

    private void SetRefreshTokenCookie(RefreshToken refreshToken)
    {
        Response.Cookies.Append(REFRESH_TOKEN, refreshToken.Token, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.None,
            Expires = refreshToken.ExpiresAt
        });
    }

    private string GetRefreshTokenCookie()
    {
        var cookie = Request.Cookies[REFRESH_TOKEN];

        if (cookie == null)
        {
            throw new KeyNotFoundException("Required cookie not found");
        }

        return cookie;
    }

    private void DeleteRefreshTokenCookie()
    {
        Response.Cookies.Delete(REFRESH_TOKEN);
    }
}