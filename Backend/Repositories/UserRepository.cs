using Backend.Models;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class UserRepository(AppDbContext context) : IUserRepository
{
    private readonly AppDbContext _context = context;

    public async Task<bool> CheckUserExistsByName(string username)
    {
        var exists = await _context.Users
        .AnyAsync(u => u.Username == username);

        return exists;
    }

    public async Task<User?> GetUser(string username)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

        return user;
    }

    public async Task RegisterUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }
}