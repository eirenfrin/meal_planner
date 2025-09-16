using Backend.Repositories.Interfaces;
using Backend.Services.Interfaces;

namespace Backend.Services;
public class UserService(IUserRepository userRepository) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;
}