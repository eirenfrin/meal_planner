using Backend.Models;
using Backend.Repositories.Interfaces;

namespace Backend.Repositories;

public class RecipeRepository(AppDbContext context) : IRecipeRepository
{
    private readonly AppDbContext _context = context;

    public Recipe GetRecipe(Guid id)
    {
        var recipe = _context.Recipes.FirstOrDefault(r => r.Id == id) ?? throw new InvalidOperationException("Recipe not found.");
        return recipe;
    }
}