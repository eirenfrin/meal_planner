
using System.ComponentModel.DataAnnotations;

namespace Backend.Models;
public class User
{
    [Key]
    public required Guid Id { get; set; }

    [Required]
    public required string Username { get; set; }

    [Required]
    public required string Password { get; set; }

    public required int? ShoppingInterval { get; set; }
}