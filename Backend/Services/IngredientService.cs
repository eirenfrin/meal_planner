using System.Data;
using Backend.Dtos;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Backend.Services.Interfaces;

namespace Backend.Services;

public class IngredientService(IIngredientRepository ingredientRepository) : IIngredientService
{
    private readonly IIngredientRepository _ingredientRepository = ingredientRepository;

    public async Task<IEnumerable<GetIngredientDto>> GetAllIngredients(Guid userId)
    {
        var allExistingIngredients = await _ingredientRepository.GetAllExistingIngredients(userId);

        var ingredientDtos = allExistingIngredients.Select(i => new GetIngredientDto
        {
            Id = i.Id,
            Title = i.Title,
            UnitId = i.UnitId,
            SoldPackageSize = i.SoldPackageSize,
            CreatorId = i.CreatorId
        });

        return ingredientDtos;
    }

    public async Task<GetIngredientDto> AddNewIngredient(Guid creatorId, NewEditIngredientDto ingredientNew)
    {
        var alreadyExists = await _ingredientRepository.CheckIngredientExistsByName(creatorId, ingredientNew.Title);

        if (alreadyExists)
        {
            throw new InvalidOperationException($"Ingredient {ingredientNew.Title} already exists.");
        }

        var ingredient = new Ingredient
        {
            Id = Guid.NewGuid(),
            Title = ingredientNew.Title,
            SoldPackageSize = ingredientNew.SoldPackageSize,
            UnitId = ingredientNew.UnitId,
            CreatorId = creatorId
        };

        await _ingredientRepository.AddNewIngredient(ingredient);

        var ingredientDto = new GetIngredientDto
        {
            Id = ingredient.Id,
            Title = ingredient.Title,
            SoldPackageSize = ingredient.SoldPackageSize,
            UnitId = ingredient.UnitId,
            CreatorId = ingredient.CreatorId
        };

        return ingredientDto;
    }

    public async Task EditIngredient(Guid ingredientId, NewEditIngredientDto ingredientUpdated)
    {
        var ingredient = await _ingredientRepository.GetSingleIngredient(ingredientId);

        if (ingredient == null)
        {
            throw new KeyNotFoundException($"Ingredient with id {ingredientId} does not exist.");
        }

        var nameAlreadyTaken = await _ingredientRepository.CheckIngredientExistsByName(ingredient.CreatorId, ingredientUpdated.Title, ingredientId);

        if (nameAlreadyTaken)
        {
            throw new InvalidOperationException($"Ingredient {ingredientUpdated.Title} already exists.");
        }

        await _ingredientRepository.EditIngredient(ingredient, ingredientUpdated);
    }

    public async Task DeleteIngredient(Guid ingredientId)
    {
        var ingredient = await _ingredientRepository.GetSingleIngredient(ingredientId);

        if (ingredient == null)
        {
            throw new KeyNotFoundException($"Ingredient with id {ingredientId} does not exist.");
        }

        if (ingredient.CreatorId == null)
        {
            throw new ConstraintException("Cannot delete pre-defined ingredients.");
        }

        await _ingredientRepository.DeleteIngredient(ingredientId);
    }
}