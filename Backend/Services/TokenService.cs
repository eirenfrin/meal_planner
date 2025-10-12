
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Backend.Dtos;
using Backend.Models;
using Backend.Models.Settings;
using Backend.Repositories.Interfaces;
using Backend.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Services;

public class TokenService(IRefreshTokenRepository refreshTokenRepository, JwtSettings jwtSettings) : ITokenService
{
    private readonly IRefreshTokenRepository _refreshTokenRepository = refreshTokenRepository;
    private readonly JwtSettings _jwtSettings = jwtSettings;

    public async Task<(RefreshToken, AccessTokenDto)> GenerateNewTokens(User user)
    {
        var accessToken = GenerateAccessToken(user);
        var refreshToken = GenerateRefreshToken(user);

        await _refreshTokenRepository.SaveNewRefreshToken(refreshToken);

        return (refreshToken, accessToken);
    }

    public async Task<(RefreshToken, AccessTokenDto)> RegenerateTokens(string oldRefreshToken)
    {
        var oldStoredToken = await _refreshTokenRepository.GetExistingRefreshToken(oldRefreshToken);

        if (oldStoredToken == null || oldStoredToken.User == null || !oldStoredToken.IsActive)
        {
            throw new UnauthorizedAccessException($"Invalid or expired refresh token");
        }

        var accessToken = GenerateAccessToken(oldStoredToken.User);
        var newRefreshToken = GenerateRefreshToken(oldStoredToken.User);

        await _refreshTokenRepository.RotateRefreshToken(oldStoredToken, newRefreshToken);

        return (newRefreshToken, accessToken);
    }

    public async Task RevokeTokenOnLogout(string refreshToken)
    {
        var storedToken = await _refreshTokenRepository.GetExistingRefreshToken(refreshToken);

        if (storedToken != null && storedToken.IsActive)
        {
            await _refreshTokenRepository.RevokeRefreshToken(storedToken);
        }
    }

    private AccessTokenDto GenerateAccessToken(User user)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Name, user.Username),
            new(JwtRegisteredClaimNames.Iat, new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
            new("mpi", user.MealPrepInterval.ToString(), ClaimValueTypes.Integer32),
        };

        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SigningKey));
        var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

        var jwtToken = new JwtSecurityToken(
            expires: DateTime.UtcNow.AddMinutes(20),
            signingCredentials: credentials,
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims
        );

        return new AccessTokenDto
        {
            Token = new JwtSecurityTokenHandler().WriteToken(jwtToken)
        };
    }

    private static RefreshToken GenerateRefreshToken(User user)
    {
        var refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

        return new RefreshToken
        {
            Id = Guid.NewGuid(),
            Token = refreshToken,
            ExpiresAt = DateTime.UtcNow.AddDays(14),
            UserId = user.Id
        };
    }
}