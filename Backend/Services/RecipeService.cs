using Backend.Dtos;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Backend.Services.Interfaces;

namespace Backend.Services;

public class RecipeService(
    IRecipeRepository recipeRepository,
    IRecipeIngredientRepository recipeIngredientRepository,
    IUnitsRecipeRepository unitsRecipeRepository,
    IUserCookedRecipeRepository userCookedRecipeRepository
) : IRecipeService
{
    private readonly IRecipeRepository _recipeRepository = recipeRepository;

    private readonly IRecipeIngredientRepository _recipeIngredientRepository = recipeIngredientRepository;

    private readonly IUnitsRecipeRepository _unitsRecipeRepository = unitsRecipeRepository;

    private readonly IUserCookedRecipeRepository _userCookedRecipeRepository = userCookedRecipeRepository;

    public async Task<GetRecipeAllInfoDto> GetSingleRecipe(Guid recipeId)
    {
        var recipe = await _recipeRepository.GetSingleRecipeWithAllInfo(recipeId);

        if (recipe == null)
        {
            throw new KeyNotFoundException($"Recipe {recipeId} not found.");
        }

        var recipeDto = new GetRecipeAllInfoDto
        {
            Id = recipe.Id,
            Title = recipe.Title,
            LastCooked = recipe.LastCooked,
            Ingredients = recipe.RecipeIngredients.Select(ri => new GetRecipeIngredientDto
            {
                IngredientTitle = ri.Ingredient!.Title,
                Amount = ri.Amount,
                UnitTitle = ri.Unit!.Title
            }),
            RecipeAmount = recipe.UnitsRecipes.Select(ur => new GetUnitsRecipeDto
            {
                UnitRecipeTitle = ur.Unit!.Title,
                RecipeAmount = ur.RecipeAmount
            })
        };

        return recipeDto;
    }

    public async Task<IEnumerable<GetRecipeBasicInfoDto>> GetAllRecipes(Guid userId)
    {
        var recipes = await _recipeRepository.GetAllRecipes(userId);

        var recipesDtos = recipes.Select(r => new GetRecipeBasicInfoDto
        {
            Id = r.Id,
            Title = r.Title,
            LastCooked = r.LastCooked
        });

        return recipesDtos;
    }

    public async Task<GetRecipeAllInfoDto> AddNewRecipe(Guid creatorId, NewEditRecipeDto newRecipe)
    {
        var alreadyExists = await _recipeRepository.CheckRecipeAlreadyExistsByTitle(creatorId, newRecipe.Title);

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
            CreatorId = creatorId,
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

    public async Task EditRecipe(Guid creatorId, Guid recipeId, NewEditRecipeDto recipeEdited)
    {
        var exists = await _recipeRepository.CheckRecipeAlreadyExistsByTitle(creatorId, recipeEdited.Title, recipeId);

        if (exists)
        {
            throw new InvalidOperationException($"Recipe {recipeEdited.Title} already exists");
        }

        var recipeExisting = await _recipeRepository.GetSingleRecipeForEditing(recipeId);

        if (recipeExisting == null)
        {
            throw new KeyNotFoundException($"Recipe {recipeId} not found.");
        }

        var recipeUpdated = new Recipe
        {
            Id = recipeId,
            Title = recipeEdited.Title,
            LastCooked = recipeExisting.LastCooked,
            CreatorId = creatorId,
        };

        await _recipeRepository.EditRecipe(recipeUpdated, recipeExisting);

        await _recipeIngredientRepository.EditAllRecipeIngredients(recipeId, recipeEdited.RecipeIngredients);

        await _unitsRecipeRepository.EditAllUnitsRecipe(recipeId, recipeEdited.UnitsRecipe);
    }

    public async Task PlanToCookRecipe(Guid userId, PlanRecipeDto plannedRecipe)
    {
        var plan = new UserCookedRecipe
        {
            Id = Guid.NewGuid(),
            PlannedStartDate = plannedRecipe.PlannedStartDate,
            PlannedEndDate = plannedRecipe.PlannedEndDate,
            AmountToCook = plannedRecipe.AmountToCook,
            UserId = userId,
            RecipeId = plannedRecipe.RecipeId
        };

        await _userCookedRecipeRepository.PlanRecipe(plan);
    }

    public async Task<IEnumerable<GetPlannedRecipesDto>> GetRecipesPlannedForDate(Guid userId, DateTime plannedForDate)
    {
        var recipes = await _userCookedRecipeRepository.GetRecipesPlannedForDate(userId, plannedForDate);

        var plannedRecipesDtos = recipes.Select(ucr => new GetPlannedRecipesDto
        {
            AmountToCook = ucr.AmountToCook,
            Title = ucr.Recipe!.Title,
            PlannedStartDate = ucr.PlannedStartDate,
            PlannedEndDate = ucr.PlannedEndDate,
            LastCooked = ucr.Recipe.LastCooked,
            RecipeAmount = ucr.Recipe.UnitsRecipes.Select(ur => new GetUnitsRecipeDto
            {
                UnitRecipeTitle = ur.Unit!.Title,
                RecipeAmount = ur.RecipeAmount
            })
        });

        return plannedRecipesDtos;
    }

}