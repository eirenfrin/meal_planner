using Backend.Dtos;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Backend.Services.Interfaces;

namespace Backend.Services;

public class UserService(IUserRepository userRepository, ITokenService tokenService) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly ITokenService _tokenService = tokenService;

    public async Task RegisterUser(AuthenticationDto register)
    {
        var usernameAlreadyExists = await _userRepository.CheckUserExistsByName(register.Username);

        if (usernameAlreadyExists)
        {
            throw new InvalidOperationException($"User with name {register.Username} already exists");
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = register.Username,
            Password = HashUserPassword(register.Password),
            MealPrepInterval = 7
        };

        await _userRepository.RegisterUser(user);
    }

    public async Task<(RefreshToken, AccessTokenDto)> LoginUser(AuthenticationDto login)
    {
        var user = await _userRepository.GetUser(login.Username);

        if (user == null || !BCrypt.Net.BCrypt.Verify(login.Password, user.Password))
        {
            throw new UnauthorizedAccessException($"Invalid email or password");
        }

        var tokens = await _tokenService.GenerateNewTokens(user);

        return tokens;
    }

    public async Task LogoutUser(string refreshToken)
    {
        await _tokenService.RevokeTokenOnLogout(refreshToken);
    }

    public async Task<(RefreshToken, AccessTokenDto)> RefreshTokens(string oldRefreshToken)
    {
        var tokens = await _tokenService.RegenerateTokens(oldRefreshToken);

        return tokens;
    }

    private static string HashUserPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
}