using Backend.Dtos;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Backend.Services.Interfaces;

namespace Backend.Services;

public class RecipeService(IRecipeRepository recipeRepository, IRecipeIngredientRepository recipeIngredientRepository, IUnitsRecipeRepository unitsRecipeRepository) : IRecipeService
{
    private readonly IRecipeRepository _recipeRepository = recipeRepository;

    public async Task<RecipeInfoDto> GetSingleRecipe(Guid recipeId)
    {
        var recipe = await _recipeRepository.GetSingleRecipeWithAllInfo(recipeId);

        if (recipe == null)
        {
            throw new KeyNotFoundException("recipe not found.");
        }

        var recipeDto = new RecipeInfoDto
        {
            Title = recipe.Title,
            LastCooked = recipe.LastCooked,
            Ingredients = recipe.RecipeIngredients.Select(ri => new RecipeIngredientDto
            {
                IngredientTitle = ri.Ingredient.Title,
                Amount = ri.Amount,
                UnitTitle = ri.Unit.Title
            }),
            RecipeAmount = recipe.UnitsRecipes.Select(ur => new UnitsRecipeDto
            {
                UnitRecipeTitle = ur.Unit.Title,
                RecipeAmount = ur.RecipeAmount
            })
        };

        return recipeDto;
    }

    public async Task<IEnumerable<Recipe>> GetAllRecipes(Guid userId)
    {
        var recipes = await _recipeRepository.GetAllRecipes(userId);

        return recipes;
    }

    public async Task<NewRecipeDto> AddNewRecipe(Guid userId, NewRecipeDto newRecipe)
    {

        var recipeId = Guid.NewGuid();

        var recipe = new Recipe
        {
            Id = recipeId,
            Title = newRecipe.Title,
            LastCooked = null,
            CreatorId = userId,
            RecipeIngredients = newRecipe.RecipeIngredients.Select(ri => new RecipeIngredient
            {
                Id = Guid.NewGuid(),
                Amount = ri.IngredientAmount,
                RecipeId = recipeId,
                IngredientId = ri.IngredientId,
                UnitId = ri.UnitId
            }).ToList(),
            UnitsRecipes = newRecipe.UnitsRecipe.Select(ur => new UnitsRecipe
            {
                Id = Guid.NewGuid(),
                RecipeAmount = ur.RecipeAmount,
                RecipeId = recipeId,
                UnitId = ur.UnitId
            }).ToList()
        };

        var recipeAdded = await _recipeRepository.AddRecipe(recipe);

        //return a dto with all infos about recipe
        
    }

    public async Task DeleteRecipe(Guid recipeId)
    {
        await _recipeRepository.DeleteRecipe(recipeId);
    }
}