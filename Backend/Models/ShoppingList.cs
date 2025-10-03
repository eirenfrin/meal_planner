using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class ShoppingList
{
    [Key]
    public required Guid Id { get; set; }

    public required DateTime? PlannedStartDate { get; set; }

    [Required]
    public required string Title { get; set; }

    [Required]
    public required bool IsDefault { get; set; }

    [Required]
    public required Guid CreatorId { get; set; }

    [ForeignKey("CreatorId")]
    public User? Creator { get; set; }

    public ICollection<ShoppingListIngredient> ShoppingListIngredients { get; set; } = new List<ShoppingListIngredient>();
}