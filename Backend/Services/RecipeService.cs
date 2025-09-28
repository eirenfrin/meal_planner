using Backend.Dtos;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Backend.Services.Interfaces;

namespace Backend.Services;

public class RecipeService(IRecipeRepository recipeRepository, IRecipeIngredientRepository recipeIngredientRepository, IUnitsRecipeRepository unitsRecipeRepository) : IRecipeService
{
    private readonly IRecipeRepository _recipeRepository = recipeRepository;

    private readonly IRecipeIngredientRepository _recipeIngredientRepository = recipeIngredientRepository;

    private readonly IUnitsRecipeRepository _unitsRecipeRepository = unitsRecipeRepository;

    public async Task<GetRecipeInfoDto> GetSingleRecipe(Guid recipeId)
    {
        var recipe = await _recipeRepository.GetSingleRecipeWithAllInfo(recipeId);

        if (recipe == null)
        {
            throw new KeyNotFoundException($"Recipe {recipeId} not found.");
        }

        var recipeDto = new GetRecipeInfoDto
        {
            Id = recipe.Id,
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

    public async Task<GetRecipeInfoDto> AddNewRecipe(Guid userId, NewRecipeDto newRecipe)
    {
        var alreadyExists = await _recipeRepository.CheckRecipeAlreadyExistsByTitle(newRecipe.Title);

        if (alreadyExists)
        {
            throw new InvalidOperationException($"Recipe {newRecipe.Title} already exists");
        }

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

        await _recipeRepository.AddRecipe(recipe);

        var recipeDto = await GetSingleRecipe(recipeId);

        return recipeDto;

    }

    public async Task DeleteRecipe(Guid recipeId)
    {
        var recipe = await _recipeRepository.GetSingleRecipe(recipeId);

        if (recipe == null)
        {
            throw new KeyNotFoundException($"Recipe {recipeId} not found.");
        }

        await _recipeRepository.DeleteRecipe(recipe);
    }

    public async Task EditRecipe(Guid recipeId, NewRecipeDto recipeEdited)
    {
        var exists = await _recipeRepository.CheckRecipeAlreadyExistsByTitle(recipeEdited.Title);

        if (exists)
        {
            throw new InvalidOperationException($"Recipe {recipeEdited.Title} already exists");
        }

        var recipeExisting = await _recipeRepository.GetSingleRecipeForEditing(recipeId);

        if (recipeExisting == null)
        {
            throw new KeyNotFoundException($"Recipe {recipeId} not found.");
        }

        await _recipeIngredientRepository.EditAllRecipeIngredients(recipeId, recipeEdited.RecipeIngredients);

        await _unitsRecipeRepository.EditAllUnitsRecipe(recipeId, recipeEdited.UnitsRecipe);
    }

}