using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class RefreshToken
{
    [Key]
    public required Guid Id { get; set; }

    [Required]
    public required string Token { get; set; }

    [Required]
    public required DateTime ExpiresAt { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? RevokedAt { get; set; }

    [Required]
    public required Guid UserId { get; set; }

    [ForeignKey("UserId")]
    public User? User { get; set; }

    public bool IsExpired => DateTime.UtcNow > ExpiresAt;
    public bool IsRevoked => RevokedAt != null;
    public bool IsActive => !IsExpired && !IsRevoked;
}