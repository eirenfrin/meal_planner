using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class Unit
{
    [Key]
    public required Guid Id { get; set; }

    [Required]
    public required string Title { get; set; }

    public required Guid? CreatorId { get; set; }

    [ForeignKey("CreatorId")]
    public User? Creator { get; set; }
}