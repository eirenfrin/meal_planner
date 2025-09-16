using Backend.Models;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class RecipeRepository(AppDbContext context) : IRecipeRepository
{
    private readonly AppDbContext _context = context;

    public async Task<Recipe> GetSingleRecipe(Guid recipeId)
    {
        var recipe = await _context.Recipes
            .FirstOrDefaultAsync(r => r.Id == recipeId) ?? throw new InvalidOperationException("Recipe not found.");
        return recipe;
    }

    public async Task<IEnumerable<Recipe>> GetAllRecipes(Guid creatorId)
    {
        var allRecipes = await _context.Recipes
        .Where(r => r.CreatorId == creatorId).ToListAsync();
        
        return allRecipes;
    }

    public async Task<Recipe> AddRecipe(Recipe recipe)
    {
        _context.Recipes.Add(recipe);
        await _context.SaveChangesAsync();
        return recipe;
    }

    public async Task<Recipe> EditRecipe(Recipe recipeUpdated)
    {
        var recipeExisting = await GetSingleRecipe(recipeUpdated.Id);
        _context.Entry(recipeExisting).CurrentValues.SetValues(recipeUpdated);
        await _context.SaveChangesAsync();
        return recipeExisting;

    }

    public async Task<Recipe> DeleteRecipe(Guid recipeId)
    {
        var recipe = await GetSingleRecipe(recipeId);
        _context.Recipes.Remove(recipe);
        await _context.SaveChangesAsync();

        return recipe;
    }

}