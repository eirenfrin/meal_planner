
using Backend.Repositories.Interfaces;
using Backend.Services.Interfaces;

namespace Backend.Services;
public class RecipeIngredientService(IRecipeIngredientRepository recipeIngredientRepository) : IRecipeIngredientService
{
    private readonly IRecipeIngredientRepository _recipeIngredientRepository = recipeIngredientRepository;
}