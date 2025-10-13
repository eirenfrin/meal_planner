using Backend.Dtos;

namespace Backend.Repositories.Interfaces;

public interface IRecipeIngredientRepository
{
    public Task EditAllRecipeIngredients(Guid recipeId, IEnumerable<NewEditRecipeIngredientDto> editedIngredients);
}