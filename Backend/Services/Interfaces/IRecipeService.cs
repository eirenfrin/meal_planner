using Backend.Models;

namespace Backend.Services.Interfaces;

public interface IRecipeService
{
    public Task<Recipe> GetSingleRecipe(Guid recipeId);

    public Task<IEnumerable<Recipe>> GetAllRecipes(Guid userId);
}