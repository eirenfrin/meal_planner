using Backend.Dtos;
using Backend.Models;

namespace Backend.Services.Interfaces;

public interface ITokenService
{
    public Task<(RefreshToken, AccessTokenDto)> GenerateNewTokens(User user);

    public Task<(RefreshToken, AccessTokenDto)> RegenerateTokens(string oldRefreshToken);

    public Task RevokeTokenOnLogout(string refreshToken);
}