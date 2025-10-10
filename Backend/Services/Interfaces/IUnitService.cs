using Backend.Dtos;
using Backend.Models;

namespace Backend.Services.Interfaces;

public interface IUnitService
{
    public Task<IEnumerable<GetUnitDto>> GetAllUnits(Guid userId);

    public Task EditUnit(Guid unitId, NewUnitDto unitEdited);

    public Task<GetUnitDto> AddNewUnit(NewUnitDto unitNew);

    public Task DeleteUserDefinedUnit(Guid unitId);
}