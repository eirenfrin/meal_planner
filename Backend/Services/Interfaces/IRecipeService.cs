using Backend.Dtos;
using Backend.Models;

namespace Backend.Services.Interfaces;

public interface IRecipeService
{
    public Task<GetRecipeInfoDto> GetSingleRecipe(Guid recipeId);

    public Task<IEnumerable<Recipe>> GetAllRecipes(Guid userId);

    public Task<GetRecipeInfoDto> AddNewRecipe(Guid userId, NewRecipeDto newRecipe);

    public Task DeleteRecipe(Guid recipeId);

    public Task EditRecipe(Guid recipeId, NewRecipeDto recipeEdited);
}