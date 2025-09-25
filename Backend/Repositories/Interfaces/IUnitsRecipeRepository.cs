using Backend.Models;

namespace Backend.Repositories.Interfaces;
public interface IUnitsRecipeRepository
{
    public Task<IEnumerable<UnitsRecipe>> GetAmountForRecipe(Guid recipeId);
}