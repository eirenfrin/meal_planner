
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class ShoppingListIngredient
{
    [Key]
    public required Guid Id { get; set; }

    public required float? IngredientAmount { get; set; }

    public required Guid? UnitId { get; set; }

    [Required]
    public required Guid ShoppingListId { get; set; }

    [Required]
    public required Guid IngredientId { get; set; }

    [ForeignKey("ShoppingListId")]
    public ShoppingList? ShoppingList { get; set; }

    [ForeignKey("IngredientId")]
    public Ingredient? Ingredient { get; set; }

    [ForeignKey("UnitId")]
    public Unit? Unit { get; set; }
}