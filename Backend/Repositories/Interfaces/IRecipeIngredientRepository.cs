using Backend.Models;

namespace Backend.Repositories.Interfaces;
public interface IRecipeIngredientRepository
{
    public Task<IEnumerable<RecipeIngredient>> GetIngredientsForRecipe(Guid recipeId);
}