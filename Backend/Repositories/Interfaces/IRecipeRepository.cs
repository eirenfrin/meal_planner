using Backend.Models;

namespace Backend.Repositories.Interfaces;

public interface IRecipeRepository
{
    public Task<Recipe> GetSingleRecipe(Guid recipeId);

    public Task<IEnumerable<Recipe>> GetAllRecipes(Guid creatorId);

    public Task<Recipe> AddRecipe(Recipe recipe);

    public Task<Recipe> EditRecipe(Recipe recipeUpdated);

    public Task<Recipe> DeleteRecipe(Guid recipeId);


}