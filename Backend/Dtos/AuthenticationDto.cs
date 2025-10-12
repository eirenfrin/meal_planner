using System.ComponentModel.DataAnnotations;
using Backend.Validators;

namespace Backend.Dtos;

public class AuthenticationDto
{
    [StringLength(30, MinimumLength = 4)]
    public required string Username { get; set; }

    [PasswordValidator]
    public required string Password { get; set; }
}