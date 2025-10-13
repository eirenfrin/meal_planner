using Backend.Dtos;
using Backend.Models;

namespace Backend.Services.Interfaces;

public interface IUnitService
{
    public Task<IEnumerable<GetUnitDto>> GetAllUnits(Guid userId);

    public Task EditUnit(Guid unitId, NewEditUnitDto unitEdited);

    public Task<GetUnitDto> AddNewUnit(Guid creatorId, NewEditUnitDto unitNew);

    public Task DeleteUserDefinedUnit(Guid unitId);
}