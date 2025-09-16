using Backend.Models;
using Backend.Repositories.Interfaces;
using Backend.Services.Interfaces;

namespace Backend.Services;

public class RecipeService(IRecipeRepository recipeRepository, IRecipeIngredientRepository recipeIngredientRepository) : IRecipeService
{
    private readonly IRecipeRepository _recipeRepository = recipeRepository;

    private readonly IRecipeIngredientRepository _recipeIngredientRepository = recipeIngredientRepository;
    public async Task<Recipe> GetSingleRecipe(Guid recipeId)
    {
        var recipe = await _recipeRepository.GetSingleRecipe(recipeId);
        var ingredients = await _recipeIngredientRepository.GetIngredientsForRecipe(recipeId);
    }

    public async Task<IEnumerable<Recipe>> getAllRecipes()
    { 

    }

    private static void AdditionalPrint()
    {
        Console.WriteLine("getting recipe");
    }
}