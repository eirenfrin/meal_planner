using Backend.Dtos;

namespace Backend.Repositories.Interfaces;

public interface IUnitsRecipeRepository
{
    public Task EditAllUnitsRecipe(Guid recipeId, IEnumerable<NewUnitsRecipeDto> unitsRecipeEdited);
}