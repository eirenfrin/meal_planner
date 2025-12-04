using Backend.Dtos;
using Backend.Models;

namespace Backend.Repositories.Interfaces;

public interface IUnitRepository
{
    public Task<IEnumerable<Unit>> GetAllUnits(Guid userId);

    public Task DeleteUnit(Unit unit);

    public Task DeleteBatchUnits(IEnumerable<Unit> unitsToDelete);

    public Task AddNewUnit(Unit newUnit);

    public Task EditUnit(Unit unitExisting, NewEditUnitDto unitEdited);

    public Task<Unit?> GetSingleUnit(Guid unitId);

    public Task<IEnumerable<Unit>> GetMultipleUnits(IEnumerable<Guid> ids);

    public Task<bool> CheckUnitExistsByName(Guid? creatorId, string unitTitle, Guid? unitId = null);

}