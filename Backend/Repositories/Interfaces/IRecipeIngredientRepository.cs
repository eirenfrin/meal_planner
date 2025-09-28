using Backend.Dtos;
using Backend.Models;

namespace Backend.Repositories.Interfaces;

public interface IRecipeIngredientRepository
{
    public Task EditAllRecipeIngredients(Guid recipeId, IEnumerable<NewRecipeIngredientDto> editedIngredients);

    public Task DeleteRecipeIngredient(Guid recipeId, Guid ingredientId);

    public Task EditRecipeIngredient(Guid recipeId, NewRecipeIngredientDto recipeIngredientEdited);

    public Task AddRecipeIngredient(Guid recipeId, NewRecipeIngredientDto recipeIngredientNew);
}