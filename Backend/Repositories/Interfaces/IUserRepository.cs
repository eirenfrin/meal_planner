using Backend.Models;

namespace Backend.Repositories.Interfaces;

public interface IUserRepository
{
    public Task<bool> CheckUserExistsByName(string username);

    public Task<User?> GetUser(string username);

    public Task RegisterUser(User user);
}