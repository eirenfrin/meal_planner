

using System.ComponentModel;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

class RecipeIngredientDto
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required float? Amount { get; set; }
}

public class RecipeIngredientRepository(AppDbContext context) : IRecipeIngredientRepository
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<RecipeIngredientDto>> GetIngredientsForRecipe(Guid recipeId)
    {
        var ingredients = await _context.RecipeIngredients
            .Where(ri => ri.RecipeId == recipeId)
            .Select(ri => new RecipeIngredientDto
            {
                Id = ri.Ingredient!.Id,
                Name = ri.Ingredient!.Title,
                Amount = ri.Amount
            })
            .ToListAsync();

        return ingredients;
    }
}