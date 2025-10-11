using Backend.Models;

namespace Backend.Repositories.Interfaces;

public interface IRecipeRepository
{
    public Task<Recipe?> GetSingleRecipeWithAllInfo(Guid recipeId);

    public Task<IEnumerable<Recipe>> GetAllRecipes(Guid creatorId);

    public Task AddRecipe(Recipe recipe);

    public Task EditRecipe(Recipe recipeUpdated, Recipe recipeExisting);

    public Task DeleteRecipe(Recipe recipe);

    public Task<Recipe?> GetSingleRecipe(Guid recipeId);

    public Task<bool> CheckRecipeAlreadyExistsByTitle(Guid creatorId, string title);

    public Task<Recipe?> GetSingleRecipeForEditing(Guid recipeId);

}