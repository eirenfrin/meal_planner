using Backend.Dtos;
using Backend.Models;

namespace Backend.Services.Interfaces;

public interface IUserService
{
    public Task RegisterUser(AuthenticationDto register);

    public Task<(RefreshToken, AccessTokenDto)> LoginUser(AuthenticationDto login);

    public Task LogoutUser(string refreshToken);

    public Task<(RefreshToken, AccessTokenDto)> RefreshTokens(string oldRefreshToken);
}