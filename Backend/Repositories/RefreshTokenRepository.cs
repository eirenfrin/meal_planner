using Backend.Models;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class RefreshTokenRepository(AppDbContext context) : IRefreshTokenRepository
{
    private readonly AppDbContext _context = context;

    public async Task<RefreshToken?> GetExistingRefreshToken(string token)
    {
        var refreshToken = await _context.RefreshTokens
        .Include(rt => rt.User)
        .FirstOrDefaultAsync(t => t.Token == token);

        return refreshToken;
    }

    public async Task RotateRefreshToken(RefreshToken oldToken, RefreshToken newToken)
    {
        oldToken.RevokedAt = DateTime.UtcNow;
        await SaveNewRefreshToken(newToken);
    }

    public async Task SaveNewRefreshToken(RefreshToken newToken)
    {
        _context.RefreshTokens.Add(newToken);
        await _context.SaveChangesAsync();
    }

    public async Task RevokeRefreshToken(RefreshToken refreshToken)
    {
        refreshToken.RevokedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();
    }
}