using Backend.Dtos;
using Backend.Models;

namespace Backend.Services.Interfaces;

public interface IIngredientService
{
    public Task<IEnumerable<GetIngredientDto>> GetAllIngredients(Guid userId);

    public Task<GetIngredientDto> AddNewIngredient(Guid creatorId, NewEditIngredientDto ingredientNew);

    public Task EditIngredient(Guid ingredientId, NewEditIngredientDto ingredientUpdated);

    public Task DeleteIngredient(Guid ingredientId);

    public Task BatchDeleteIngredients(BatchDeleteDto idsToDelete);
}