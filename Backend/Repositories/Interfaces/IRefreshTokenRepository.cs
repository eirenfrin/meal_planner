using Backend.Models;

namespace Backend.Repositories.Interfaces;

public interface IRefreshTokenRepository
{
    public Task<RefreshToken?> GetExistingRefreshToken(string token);

    public Task RotateRefreshToken(RefreshToken oldToken, RefreshToken newToken);

    public Task SaveNewRefreshToken(RefreshToken newToken);

    public Task RevokeRefreshToken(RefreshToken refreshToken);
}