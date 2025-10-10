
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Backend.Dtos;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Backend.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Services;

public class TokenService(IConfiguration configuration, IRefreshTokenRepository refreshTokenRepository) : ITokenService
{
    private readonly IConfiguration _configuration = configuration;
    private readonly IRefreshTokenRepository _refreshTokenRepository = refreshTokenRepository;

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
            throw new InvalidOperationException($"Invalid or expired refresh token");
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
            new("mpi", user.MealPrepInterval.ToString()),
        };

        var jwtKey = _configuration["Jwt:SigningKey"]!;
        var issuer = _configuration["Jwt:Issuer"]!;
        var audience = _configuration["Jwt:Audience"]!;

        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

        var jwtToken = new JwtSecurityToken(
            expires: DateTime.UtcNow.AddMinutes(20),
            signingCredentials: credentials,
            issuer: issuer,
            audience: audience,
            claims: claims
        );

        return new AccessTokenDto
        {
            AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken)
        };
    }

    private RefreshToken GenerateRefreshToken(User user)
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