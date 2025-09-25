using Backend.Dtos;
using Backend.Models;

namespace Backend.Repositories.Interfaces;

public interface IUnitRepository
{
    public Task<IEnumerable<Unit>> GetAllUnits(Guid userId);

    public Task DeleteUnit(Unit unit);

    public Task<Unit> AddNewUnit(Unit newUnit);

    public Task EditUnit(Unit unitExisting, NewUnitDto unitEdited);

    public Task<Unit?> GetSingleUnit(Guid unitId);

    public Task<bool> CheckUnitExistsByName(string unitTitle);

}